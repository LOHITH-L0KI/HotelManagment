
using System.ComponentModel.DataAnnotations;

namespace Persistance.DataSets
{
    public enum RoomType
    {
        Delux,
        King,
        Queen
    }

    public class Room_Details
    {
        public Guid Id { get; set; }
        public uint Number { get; set; }
        public uint Floor { get; set; }
        public RoomType Type { get; set; }
        public uint Price { get; set; }
        public bool Status { get; set; }
        public bool HasAC { get; set; }

        //Navigation property
        public virtual ICollection<Booking_Details>? BookingDetails { get; set; }

        public Room_Details(uint number, uint floor, RoomType type, uint price, bool status, bool hasAC)
        {
            Id = Guid.NewGuid();
            Number = number;
            Floor = floor;
            Type = type;
            Price = price;
            Status = status;
            HasAC = hasAC;
        }
    }
}
