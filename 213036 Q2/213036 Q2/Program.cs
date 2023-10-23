using System;
using System.Collections.Generic;

class Flight
{
    public string FlightNumber { get; set; }
    public string Destination { get; set; }
    public int TotalSeats { get; set; }
    public int AvailableRetailSeats { get; set; }
    public int AvailableCorporateSeats { get; set; }
    public bool[] SeatAvailability { get; set; }
}

class Customer
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public bool IsCorporate { get; set; }
}

class Reservation
{
    public string PassengerName { get; set; }
    public string FlightNumber { get; set; }
    public string CustomerType { get; set; }
    public int SeatNumber { get; set; }
}

class Program
{
    static List<Flight> flights = new List<Flight>();
    static List<Customer> customers = new List<Customer>();
    static List<Reservation> reservations = new List<Reservation>();

    static void Main(string[] args)
    {
        InitializeFlights();

        while (true)
        {

            Console.WriteLine("1. List Available Flights");
            Console.WriteLine("2. Make a Reservation");
            Console.WriteLine("3. List Reservations");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListFlights();
                    break;
                case "2":
                    MakeReservation();
                    break;
                case "3":
                    ListReservations();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void InitializeFlights()
    {
        var flight1 = new Flight
        {
            FlightNumber = "FL101",
            Destination = "New York",
            TotalSeats = 100,
            AvailableRetailSeats = 80,
            AvailableCorporateSeats = 20,
            SeatAvailability = new bool[100]
        };

        var flight2 = new Flight
        {
            FlightNumber = "FL202",
            Destination = "Los Angeles",
            TotalSeats = 120,
            AvailableRetailSeats = 100,
            AvailableCorporateSeats = 20,
            SeatAvailability = new bool[120]
        };

        flights.Add(flight1);
        flights.Add(flight2);
    }

    static void ListFlights()
    {
        Console.WriteLine("Available Flights:");
        Console.WriteLine("Flight Number\tDestination\tTotal Seats\tRetail Seats\tCorporate Seats");
        foreach (var flight in flights)
        {
            Console.WriteLine($"{flight.FlightNumber}\t{flight.Destination}\t{flight.TotalSeats}\t{flight.AvailableRetailSeats}\t{flight.AvailableCorporateSeats}");
        }
    }

    static void MakeReservation()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your contact information: ");
        string contactInfo = Console.ReadLine();
        Console.Write("Enter the flight number: ");
        string flightNumber = Console.ReadLine();

        Flight selectedFlight = flights.Find(f => f.FlightNumber == flightNumber);

        if (selectedFlight == null)
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Console.Write("Are you a corporate customer? (Y/N): ");
        bool isCorporate = Console.ReadLine().Trim().Equals("Y", StringComparison.OrdinalIgnoreCase);

        if (isCorporate)
        {
            Console.Write("Enter your company name: ");
            string companyName = Console.ReadLine();
            Console.Write("Enter the contact person's name: ");
            string contactPerson = Console.ReadLine();
            customers.Add(new Customer { Name = companyName, ContactInfo = contactPerson, IsCorporate = true });
            selectedFlight.AvailableCorporateSeats--;
        }
        else
        {
            customers.Add(new Customer { Name = name, ContactInfo = contactInfo, IsCorporate = false });
            selectedFlight.AvailableRetailSeats--;
        }

        int seatNumber = SelectSeat(selectedFlight);
        reservations.Add(new Reservation { PassengerName = name, FlightNumber = flightNumber, CustomerType = isCorporate ? "Corporate" : "Retail", SeatNumber = seatNumber });
        Console.WriteLine("Reservation successful.");
    }

    static int SelectSeat(Flight flight)
    {
        Console.WriteLine("Select a seat number (1-" + flight.TotalSeats + "):");
        int seatNumber = 0;
        bool isSeatValid = false;

        while (!isSeatValid)
        {
            if (int.TryParse(Console.ReadLine(), out seatNumber) && seatNumber >= 1 && seatNumber <= flight.TotalSeats && !flight.SeatAvailability[seatNumber - 1])
            {
                flight.SeatAvailability[seatNumber - 1] = true;
                isSeatValid = true;
            }
            else
            {
                Console.WriteLine("Invalid seat selection. Please try again.");
            }
        }

        return seatNumber;
    }

    static void ListReservations()
    {
        Console.WriteLine("Your Reservations:");
        Console.WriteLine("Passenger Name\tFlight Number\tCustomer Type\tSeat Number");
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"{reservation.PassengerName}\t{reservation.FlightNumber}\t{reservation.CustomerType}\t{reservation.SeatNumber}");
        }
    }
}

