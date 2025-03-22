
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistance.DataSets
{
    public enum UserType : ushort
    {
        Administrator,
        Manager,
        Default
    }

    public class User_Details
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string ContactNumber { get; set; }

        public UserType Type { get; set; }

        //navigation property
        public User_Login_Data? UserLoginData;

        public User_Details(string firstName,
                            string lastName,
                            string email,
                            string contactNumber,
                            UserType type)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
            Type = type;
        }

    }
}
