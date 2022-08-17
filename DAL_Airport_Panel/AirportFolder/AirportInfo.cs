using DAL_Airport_Panel.AirplaneFolder;
using DAL_DAL_Airport_Panel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Airport_Panel
{
    public class AirportInfo : IEnumerable
    {
        private List<Flight> Flights { get; set; }
        public AirportInfo(List<Flight> flights = null!)
        {
            if(flights != null)
            {
                Flights = flights;
            }
            else
            {
                Flights = new List<Flight>();
            }
        }

        public enum EmergencyType { Evacuation, Fire }
        public static Flight Search(List<Flight> flights, int id = 0)
        {
            Flight flight = flights.Where(i => i.ID == id).FirstOrDefault()!;
            if (flight != null)
            {
                Console.WriteLine("Searching by ID succeed !");
                return flight;
            }
            else
            {
                throw new NullReferenceException("The flight you were searching is null !");
            }
        }
        //Searching passengers
        //Searching Passenger by flightID
        public static Passenger Search(Flight flight, int flightID)
        {
            if (flight != null)
            {
                Passenger passenger = flight.Passengers.Where(i => flight.ID == flightID).FirstOrDefault()!;
                Console.WriteLine("Searching passangers by ID succeed !");
                return passenger;
            }
            else
            {
                throw new NullReferenceException("The passenger you were searching is null !");
            }
        }
        //Searching Passenger by first name
        public static Passenger SearchByFirstName(Flight flight, string firstName)
        {
            if (flight != null)
            {
                Passenger passenger = flight.Passengers.Where(i => i.FirstName == firstName).FirstOrDefault()!;
                Console.WriteLine("Searching passangers by first name succeed !");
                return passenger;
            }
            else
            {
                throw new NullReferenceException("The passenger you were searching is null !");
            }
        }
        //Searching Passenger by second name
        public static Passenger SearchBySecondName(Flight flight, string secondName)
        {
            if (flight != null)
            {
                Passenger passenger = flight.Passengers.Where(i => i.SecondName == secondName).FirstOrDefault()!;
                Console.WriteLine("Searching passangers by second name succeed !");
                return passenger;
            }
            else
            {
                throw new NullReferenceException("The passenger you were searching is null !");
            }
        }
        //Searching Passenger by 
        public static Passenger Search(Flight flight, string nationality)
        {
            if (flight != null)
            {
                Passenger passenger = flight.Passengers.Where(i => i.Nationality == nationality).FirstOrDefault()!;
                Console.WriteLine("Searching passangers by passport succeed !");
                return passenger;
            }
            else
            {
                throw new NullReferenceException("The passenger you were searching is null !");
            }
        }
        //Searching Passenger by Airport
        public static Flight Search(Flight flight, Airport airport)
        {
            if (flight != null)
            {
                Passenger passanger = flight.Passengers.Where(i => flight.Airport == airport).FirstOrDefault()!;
                Console.WriteLine("Searching by airport succeed !");
                return flight;
            }
            else
            {
                throw new NullReferenceException("The flight you were searching is null !");
            }
        }
        public static Flight Search(Flight flight, DateOnly dateOfBirth)
        {
            if (flight != null)
            {
                Passenger passanger = (flight.Passengers.Where(i => i.DateOfBirth == dateOfBirth).FirstOrDefault())!;
                Console.WriteLine("Searching by airport succeed !");
                return flight;
            }
            else
            {
                throw new NullReferenceException("The flight you were searching is null !");
            }
        }
        //Searching flights
        public static Flight Search(List<Flight> flights, DateTime dateTime)
        {
            Flight flight = flights.Where(i => i.DateTime == dateTime).FirstOrDefault()!;
            if (flight != null)
            {
                Console.WriteLine("Searching by Date and Time of ariival succeed !");
                return flight;
            }
            else
            {
                throw new NullReferenceException("The flight you were searching is null !");
            }
        }
        public static Flight Search(List<Flight> flights, Airport airport)
        {
            Flight flight = flights.Where(i => i.Airport == airport).FirstOrDefault()!;
            if (flight != null)
            {
                Console.WriteLine("Searching by airport succeed !");
                return flight;
            }
            else
            {
                throw new NullReferenceException("The flight you were searching is null !");
            }
        }
        public IEnumerator GetEnumerator()
        {
            foreach(Flight item in Flights)
            {
                yield return item;
            }
        }
        public static void Emergency(EmergencyType emergency = EmergencyType.Evacuation, object obj = null!)
        {
            if(obj is Airport airport)
            {
                Console.WriteLine("Something happend in airport : \n" + airport.Name);
            }
            else if(obj is Airplane airplane)
            {
                Console.WriteLine("Something happend in airplane : \n" + airplane);
            }
            switch (emergency)
            {
                case EmergencyType.Evacuation:
                    {
                        Console.WriteLine($"Emergency hazard !!! - {DateTime.Now}\n");
                        break;
                    }
                case EmergencyType.Fire:
                    {
                        Console.WriteLine($"Fire hazard !!! - {DateTime.Now}\n");
                        break;
                    }
                default:
                    Console.WriteLine($"Another type of hazard !!! - {DateTime.Now}\n");
                    break;
            }
        }
        
    }
}
