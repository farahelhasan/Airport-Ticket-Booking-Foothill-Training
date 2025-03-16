using Airport_Ticket_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{
    class Booking
    {
        public int BookingID { set; get; }

        public int FlightID { set; get; }
        public int UserID { set; get; }

        public string Class { set; get; }
       
    }
}
