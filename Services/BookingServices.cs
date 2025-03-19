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
            double price = GetPrice(flightId, classType);
            Flight flightToBook = FlightServices.GetFlight(flightId);
            bool availableSeat = CheckAvailableSeat(flightId, classType);

            if (flightToBook != null && price > 0 && availableSeat)
            {
                Booking booking = new Booking { BookingID = 1, FlightID = flightToBook.FlightID, Class = classType, UserID = userId, Price = price };
                FileHandler.SaveBooking(booking);
                DecreaseSeatsAvailable(flightId, classType);
              
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

        public static void GetSpesificBooking(int bookingId, int userId)
        {
            List<Booking> bookings = FileHandler.ReadBookings();

            Booking selectedBooking = (from booking in bookings
                                              where booking.BookingID == bookingId
                                              && booking.UserID == userId
                                              select booking).FirstOrDefault();

            if (selectedBooking == null)
            {
                Console.WriteLine("Enter Vaild BookingId.");
            }
            else
            {
                    Console.WriteLine(selectedBooking);
            }
        }

        public static void CancelBooking(int bookingId, int userId)
        {
            List<Booking> bookings = FileHandler.ReadBookings();

            Booking selectedBooking = (from booking in bookings
                                       where booking.BookingID == bookingId
                                       && booking.UserID == userId
                                       select booking).FirstOrDefault();

            if (selectedBooking == null)
            {
                Console.WriteLine("Enter Vaild BookingId.");
            }
            else
            {
                bookings.Remove(selectedBooking);
                FileHandler.EditBooking(bookings);
                Console.WriteLine($"Bookiing with ID: {selectedBooking.BookingID} deleted successfully! ");
            }
        }

        public static void ModifyBooking(int bookingId, int userId, string className)
        {
            List<Booking> bookings = FileHandler.ReadBookings();

            Booking selectedBooking = (from booking in bookings
                                       where booking.BookingID == bookingId
                                       && booking.UserID == userId
                                       select booking).FirstOrDefault();

            if (selectedBooking == null)
            {
                Console.WriteLine("Enter Vaild BookingId.");
            }
            else
            {
                // check if the new class has available seats
                if(CheckAvailableSeat(selectedBooking.FlightID, className))
                {
                    DecreaseSeatsAvailable(selectedBooking.FlightID, className);
                    // we should increase available seats for old class 
                    IncreaseSeatsAvailable(selectedBooking.FlightID, selectedBooking.Class);
                    selectedBooking.Class = className;
                    FileHandler.EditBooking(bookings);
                    Console.WriteLine($"Bookiing with ID: {selectedBooking.BookingID} modified successfully! ");
                    Console.WriteLine(selectedBooking);
                }
              
            }
        }

        private static double GetPrice(int flightId, string className)
        {
            List<Class> classes = FileHandler.ReadClasses(ClassesFile);

            Class selectedClass = (from classType in classes
                                   where classType.FlightID == flightId
                                   && className.Equals(classType.ClassType, StringComparison.OrdinalIgnoreCase)
                                   select classType).FirstOrDefault();
            return selectedClass?.Price ?? -1;

        }

        private static void DecreaseSeatsAvailable(int flightId, string className)
        {
            List<Class> classes = FileHandler.ReadClasses(ClassesFile);

            Class selectedClass = (from classType in classes
                                   where classType.FlightID == flightId
                                   && className.Equals(classType.ClassType, StringComparison.OrdinalIgnoreCase)
                                   select classType).FirstOrDefault();

            if (selectedClass == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            selectedClass.SeatsAvailable--;
            FileHandler.EditClasses(classes);
            Console.WriteLine($"Available Seats for {selectedClass.ClassType} class decreasing successfully: {selectedClass.SeatsAvailable}");
        }

        private static bool CheckAvailableSeat(int flightId, string className)
        {
            List<Class> classes = FileHandler.ReadClasses(ClassesFile);

            Class selectedClass = (from classType in classes
                                   where classType.FlightID == flightId
                                   && className.Equals(classType.ClassType, StringComparison.OrdinalIgnoreCase)
                                   select classType).FirstOrDefault();

            if (selectedClass == null)
            {
                Console.WriteLine("Class not found.");
                return false;
            }

            if (selectedClass.SeatsAvailable > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Sorry, you cann't modifiy class, No seats available.");
                return false;
            }
        }

        private static void IncreaseSeatsAvailable(int flightId, string className)
        {
            List<Class> classes = FileHandler.ReadClasses(ClassesFile);

            Class selectedClass = (from classType in classes
                                   where classType.FlightID == flightId
                                   && className.Equals(classType.ClassType, StringComparison.OrdinalIgnoreCase)
                                   select classType).FirstOrDefault();

            if (selectedClass == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            selectedClass.SeatsAvailable++;
            FileHandler.EditClasses(classes);
            Console.WriteLine($"Available Seats for {selectedClass.ClassType} class increasing successfully: {selectedClass.SeatsAvailable}");

        }
    }
}
