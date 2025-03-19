// See https://aka.ms/new-console-template for more information
using Airport_Ticket_Booking.Models;

Console.WriteLine("Hello, World!");

Booking x = new Booking() { Class = "dd", FlightID = 1, Price = 33, UserID = 9 };
Booking r = new Booking() { Class = "dd", FlightID = 1, Price = 33, UserID = 9 };
Booking e = new Booking() { Class = "dd", FlightID = 1, Price = 33, UserID = 9 };

Console.WriteLine(x);
Console.WriteLine(r);
Console.WriteLine(e);