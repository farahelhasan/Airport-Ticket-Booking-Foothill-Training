using Airport_Ticket_Booking.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking.Services
{
    class BookingServices
    {
    
        public static void BookFlight(int flightId, string classType, int userId)
        {
            // git the price for the class 
            double price = FlightServices.GetPrice(flightId, classType);

            Flight flightToBook = FlightServices.GetFlight(flightId);
           
            if(flightToBook != null && price > 0)
            {
                Booking booking = new Booking { BookingID = 1, FlightID = flightToBook.FlightID, Class = classType, UserID = userId, Price = price };
                FileHandler.SaveBooking(booking);
                FlightServices.DecreaseSeatsAvailable(flightId, classType);
              
                Console.WriteLine("Booking Successful!");
                Console.WriteLine(booking);

            }
            else
            {
                Console.WriteLine("Enter vaild FlightId...");

            }
        }

        public static void GetUserBooking(int userId)
        {
            List<Booking> bookings = FileHandler.ReadBookings();

            List<Booking> selectedBookings = (from booking in bookings
                                      where booking.UserID == userId
                                      select booking).ToList();

            if (selectedBookings.Count() < 1)
            {
                Console.WriteLine("You haven't booked any flights yet.");
            }
            else
            {
                foreach(Booking book in selectedBookings)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public static void GetSpesificBooking(int bookingId)
        {
            List<Booking> bookings = FileHandler.ReadBookings();

            Booking selectedBooking = (Booking) (from booking in bookings
                                              where booking.BookingID == bookingId
                                              select booking);

            if (selectedBooking == null)
            {
                Console.WriteLine("Enter Vaild BookingId.");
            }
            else
            {
                    Console.WriteLine(selectedBooking);
            }
        }



    }
}
