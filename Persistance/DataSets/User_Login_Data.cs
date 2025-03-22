
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistance.DataSets
{
    public class User_Login_Data
    {
        [Key]
        [ForeignKey("User_Details")]
        public Guid UserDetails_Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(32)")]
        public string Password { get; set; }

        //navigation property
        public User_Details? UserDetails;

        public User_Login_Data(Guid userId, string userName, string password )
        {
            UserDetails_Id = userId;
            UserName = userName;
            Password = password;
        }
    }
}
