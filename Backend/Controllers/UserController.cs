using Backend.Models;
using EntityFramework.Exceptions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using Persistance.DataSets;
using System.Diagnostics;

namespace Backend.Controllers
{
    public class UserController : Controller
    {
        private PersistanceContext persistanceContext;
        UserController(PersistanceContext _persistanceContext)
        {
            persistanceContext = _persistanceContext;
        }

        [Authorize]
        [HttpPost]
        public IActionResult NewUser([FromBody] NewUserData newUser)
        {
            if (newUser.userData.hasValidData() && newUser.loginData.hasValidData())
            {
                //check if user with same username persent in db.
                bool userNameExist = !persistanceContext.userLoginDatas.Where(uld => uld.UserName == newUser.loginData.userName).Any();
                if (userNameExist)
                {
                    Debug.Fail("Error::UserName '" + newUser.loginData.userName + "' already exists.\n");
                    return StatusCode(500, new { Message = "UserName already exists.\n" });
                }

                User_Details newDbUser = new User_Details(newUser.userData.firstName
                                                        , newUser.userData.lastName
                                                        , newUser.userData.email
                                                        , newUser.userData.contactNumber
                                                        , newUser.userData.userType);

                User_Login_Data newDbLogin = new User_Login_Data(newDbUser.Id, newUser.loginData.userName, newUser.loginData.password);

                using (var trans = persistanceContext.Database.BeginTransaction())
                {
                    try
                    {
                        persistanceContext.userDetails.Add(newDbUser);
                        persistanceContext.SaveChanges();

                        persistanceContext.userLoginDatas.Add(newDbLogin);
                        persistanceContext.SaveChanges();

                        trans.Commit();
                    }
                    catch (UniqueConstraintException dupExc)
                    {
                        trans.Rollback();

                        Debug.Fail("Error::User already exists with same email or contact number. ", dupExc.Message);
                        return StatusCode(500, new { Message = "Duplicate User with same Email or contact number" });
                    }
                    catch (DbUpdateException ex)
                    {
                        trans.Rollback();

                        Debug.Fail("Error::Create New User::", ex.Message);
                        return StatusCode(500, new { Message = "Error in creating user" });
                    }
                }

                return Ok("Successfully created!");
            }

            return StatusCode(204, new {Message = "Null Fields!"});
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateUserDetails([FromBody] UserData userData)
        {
            if (userData.hasValidData())
            {
                //update database
                var currUserData = persistanceContext.userDetails
                    .Where(ud => ud.Id == userData.Id)
                    .SingleOrDefault();

                if (currUserData != null)
                {
                    currUserData.FirstName = userData.firstName;
                    currUserData.LastName = userData.lastName;
                    currUserData.ContactNumber = userData.contactNumber;
                    currUserData.Email = userData.email;
                }

                persistanceContext.SaveChanges();
                return StatusCode(500, new { Message = "Falied to Update!" });
            }

            return StatusCode(204, new { Message = "Null Fields!" });
        }
    }
}
