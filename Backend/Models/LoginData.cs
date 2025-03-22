
namespace Backend.Models
{
    public class LoginData
    {
        public required string userName;
        public required string password;

        public bool hasValidData()
        {
            return !(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password));
        }
    }
}
