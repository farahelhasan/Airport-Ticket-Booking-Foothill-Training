using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Models
{

    class Flight
    {
        public int FlightID { set; get; }
        public string DepartureCountry { set; get; }
        public string DestinationCountry { set; get; }
        public string DepartureAirport { set; get; }
        public string ArrivalAirport { set; get; }
        public DateTime DepartureDate { set; get; }


    }
}
