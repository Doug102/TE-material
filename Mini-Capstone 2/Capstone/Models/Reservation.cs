using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {
        public int ReservationId {get; set;}
        public int NumberOfAttendees {get; set;}
        public int SpaceId { get; set;}
        public DateTime ReservedFrom { get; set;}
        public DateTime ReservedTo { get; set;}
        public string ReservedFor { get; set;}
        public string VenueName { get; set; }
        public string SpaceName { get; set; }
        public decimal TotalCost { get; set; }

        public Reservation() 
        { 
        }
    }
}
