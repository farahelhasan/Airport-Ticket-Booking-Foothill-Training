// See https://aka.ms/new-console-template for more information
using Airport_Ticket_Booking.Models;
using Airport_Ticket_Booking.Services;

Console.WriteLine("Hello, World!");

List<Booking> flights = FileHandler.ReadBookings();
FileHandler.SaveBooking(flights[0]);
