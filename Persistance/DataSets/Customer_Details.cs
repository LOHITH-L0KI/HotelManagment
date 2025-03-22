

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistance.DataSets
{
    public class Customer_Details
    {
        public Guid Id { set; get; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string FirstName { set; get; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { set; get; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string ContactNumber { set; get; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Address { set; get; }

        public string? Email { set; get; }

        //navigation property
        public virtual ICollection<Booking_Details>? BookingDetails { get; set; }

        public Customer_Details(string firstName,
                                string lastName,
                                string contactNumber,
                                string address,
                                string? email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Address = address;
            Email = email;
        }
    }
}
