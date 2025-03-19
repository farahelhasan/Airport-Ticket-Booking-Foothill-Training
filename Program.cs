using Airport_Ticket_Booking.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Airport Ticket Booking System!");

        string role = UserServices.Login();  

        if (role == "Manager")
        {
            while (true)
            {
                UserServices.ShowManagerMenu();
            }
        }
        else if (role == "Passenger")
        {
            while (true)
            {
                UserServices.ShowPassengerMenu();
            }
        }
        else
        {
            Console.WriteLine("Invalid Login. Exiting...");
        }
    }
}