# Airport Ticket Booking System

## Overview
The **Airport Ticket Booking System** is a .NET console application designed to allow passengers to book flight tickets and managers to manage bookings. The system uses a file-based storage mechanism to persist data.

## Features

### For Passengers:
1. **Book a Flight**
   - Search for flights based on multiple criteria.
   - Select a class (Economy, Business, First Class) with different pricing.
2. **Search for Available Flights**
   - Filter flights based on:
     - Price
     - Departure Country
     - Destination Country
     - Departure Date
     - Departure Airport
     - Arrival Airport
     - Class
3. **Manage Bookings**
   - View all personal bookings.
   - View specific booking details.
   - Cancel a booking.
   - Modify booking class.

### For Managers:
1. **Filter Bookings**
   - Search bookings by:
     - Flight ID
     - Price
     - Departure Country
     - Destination Country
     - Departure Date
     - Departure Airport
     - Arrival Airport
     - Passenger
     - Class
2. **Batch Flight Upload**
   - Import flights from a CSV file.
3. **Validate Imported Flight Data**
   - Apply validation rules to imported flight data.
   - Provide detailed error messages for invalid entries.

## Usage
1. **Login System**
   - Users must enter a username and password.
   - The system checks credentials from a file and determines if the user is a Passenger or Manager.
2. **Booking Management**
   - Passengers can search, book, cancel, or modify bookings.
   - Managers can filter bookings and upload flights.

## File Storage
The system stores data in text files:
- `flights.csv`: Stores flight information.
- `flight_classes.csv`: Stores class information for each flight.
- `bookings.csv`: Stores booking details.
- `users.csv`: Stores user credentials and roles.

## Function Overview
### Passenger Functions:
- `BookFlight(int flightId, string classType, int userId)`
- `GetUserBooking(int userId)`
- `GetSpesificBooking(int bookingId, int userId)`
- `CancelBooking(int bookingId, int userId)`
- `ModifyBooking(int bookingId, int userId, string className)`

### Manager Functions:
- `FilterBookings(...)`
- `ImportFlightsFromCSV(string filePath)`
- `ImportClassesFromCSV(string filePath)`


