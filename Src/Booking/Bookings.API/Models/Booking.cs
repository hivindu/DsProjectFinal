using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bookings.API.Data;

namespace Bookings.API.Models
{
    public class Booking 
    {
        [Key]
        public int Id { get; set; }
        public int StudentCount { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime ReservationDate { get; set; }
        public int UserId { get; set; }
        public string Purpose { get; set; }

        public Booking()
        {

        }
    }
}
