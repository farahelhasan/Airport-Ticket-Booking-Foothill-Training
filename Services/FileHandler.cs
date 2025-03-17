using Airport_Ticket_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Services
{
    class FileHandler
    {
        private const string FlightsFile = "C:\\Users\\pc\\source\\repos\\Airport Ticket Booking\\Data\\flights.csv";

        public static List<Flight> ReadFlights()
        {
            List<Flight> flights = new List<Flight>();

            if (File.Exists(FlightsFile))
            {
                var lines = File.ReadAllLines(FlightsFile).Skip(1); // Skip header

                foreach (var line in lines)
                {
                    var values = line.Split(',');
                    if (values.Length == 6)
                    {
                        flights.Add(new Flight
                        {
                            FlightID = int.Parse(values[0]),
                            DepartureCountry = values[1],
                            DestinationCountry = values[2],
                            DepartureAirport = values[3],
                            ArrivalAirport = values[4],
                            DepartureDate = DateTime.Parse(values[5]),
                        });
                    }
                }
            }

            return flights;
        }


    }
}
