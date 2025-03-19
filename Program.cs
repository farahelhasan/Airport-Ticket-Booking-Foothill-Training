// See https://aka.ms/new-console-template for more information
using Airport_Ticket_Booking.Models;
using Airport_Ticket_Booking.Services;

//BookingServices.BookFlight(101, "Economy", 1);
//BookingServices.BookFlight(101, "Business", 4);
//BookingServices.BookFlight(101, "Economy", 2);
//BookingServices.BookFlight(101, "Business", 3);
BookingServices.ModifyBooking(2, 4, "Economy");

BookingServices.FilterBookings(destinationCountry: "UK", flightClass: "Business");
