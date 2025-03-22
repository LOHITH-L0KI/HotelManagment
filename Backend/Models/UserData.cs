using Persistance.DataSets;
using System.Text.RegularExpressions;

namespace Backend.Models
{
    public class UserData
    {
        public Guid Id;
        public required string firstName;
        public required string lastName;
        public required string email;
        public required string contactNumber;
        public required UserType userType;

        private static Regex conatctRegEx = new Regex(@"^+?[1-9][0-9]{7,14}$", RegexOptions.IgnorePatternWhitespace);
        private static Regex emailRegEx = new Regex(@"^[a-zA-Z0-9._]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
        public bool hasValidData()
        {
            return !(string.IsNullOrEmpty(firstName)|| string.IsNullOrEmpty(lastName))
                     && ValidateEmail()
                     && ValidateContact();
        }

        private bool ValidateContact()
        {
            return conatctRegEx.IsMatch(contactNumber);
        }

        private bool ValidateEmail()
        {
            return emailRegEx.IsMatch(email);
        }
    }
}
