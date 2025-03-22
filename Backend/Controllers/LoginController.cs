using Backend.Authentication;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Persistance;

namespace Backend.Controllers
{
    public class LoginController : Controller
    {
        private readonly PersistanceContext persistanceContext;

        LoginController(PersistanceContext _dbContext)
        {
            this.persistanceContext = _dbContext;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginData loginData)
        {
            if (loginData.hasValidData())
            {
                bool isValid = !persistanceContext.userLoginDatas
                    .Where(uld => (uld.UserName == loginData.userName) && (uld.Password == loginData.password))
                    .Any();

                if (isValid)
                {
                    string authToken = AuthTokenGenetator.Genetate(loginData.userName);
                    return Ok(authToken);
                }

            }
            return Unauthorized(new { Message = "Login Fail!" });
        }

        [HttpPost]
        public IActionResult LogOut([FromBody] string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return Unauthorized(new { Message = "Unauthorized operation" });
           
            /*TODO:: store the JWT token in black list and validate incoming reuest against blacklist
                                                OR
                    change secret key.
             */
            return Ok("Logged out!");
        }
    }
}
