using System.ComponentModel.DataAnnotations.Schema;

namespace Persistance.DataSets
{
    public class Booking_Details
    {
        public Guid Id { set; get; }

        [ForeignKey("Room")]
        public Guid Room_Id { set; get; }

        [ForeignKey("Customer")]
        public Guid Customer_Id { set; get; }
        
        public DateTime InTime { set; get; }
        public DateTime OutTime { set; get; }
        public bool CheckedIn { set; get; }
        public int Advance { set; get; }
        public int Rent { set; get; }
        public int Balance { set; get; }

        //navigation property
        public Customer_Details? Customer { get; set;}

        //navigation property
        public Room_Details? Room { get; set; }
    }
}
