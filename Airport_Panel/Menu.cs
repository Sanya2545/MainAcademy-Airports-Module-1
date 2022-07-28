using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    public class Menu
    {
        public static string ShowMenu()
        {
            return "1. Create flights\n" +
                   "2. Update existing data\n" +
                   "3. Delete all data\n" +
                   "4. Search Flight by ID, Date & Time, Airports\n" +
                   "5. Emergency message\n" +
                   "6. Exit";
        }
        public static Terminal CreateTerminal()
        {
            Console.Clear();
            Console.WriteLine("Creating terminals : ");
            Console.Write("Enter the name of terminal, you want to add : ");
            string name = Console.ReadLine()!;
            Console.Write("Enter the number of Gates in each terminal : ");
            int result = 0;
            int.TryParse(Console.ReadLine(), out result);
            if (name == null || result <= 0)
            {
                throw new ArgumentException("You've been putted wrong parameters !");
            }
            int[] numsOfGates = new int[result];
            for (int i = 0; i < numsOfGates.Length; ++i)
            {
                numsOfGates[i] = i + 1;
            }
            Terminal terminal = new Terminal(name, numsOfGates);
            return terminal;
        }
        public static Airplane CreateAirplane()
        {
            Console.Clear();
            string name = "";
            int typeOfPlane = 0;
            int numOfSeats = 0;
            Console.WriteLine("Creating your airplane :");
            Console.Write("Enter the name of your airplane : ");
            name = Console.ReadLine()!;
            Console.Write("Enter the type of your plane,\n1 - Boeing;\n2 - Airbus : ");
            int.TryParse(Console.ReadLine()!, out typeOfPlane);
            Console.Write("Enter the number of seats in your airplane : ");
            int.TryParse(Console.ReadLine(), out numOfSeats);
            if (name == null || typeOfPlane < 1 || typeOfPlane > 2 || numOfSeats <= 6)
            {
                throw new ArgumentException("Ypu've been putted wrong parameter !");
            }
            Airplane airplane = new Airplane(name, (Airplane.TypeOfPlane)typeOfPlane, numOfSeats);
            return airplane;
        }
        public static Airport CreateAirport()
        {
            Console.Clear();
            string name = "";
            Console.WriteLine("Creating Airport : ");
            Console.Write("Enter name of Airport : ");
            name = Console.ReadLine()!;
            List<Terminal> terminals = new();
            Console.Write("How many terminals you want to add to the airport : ");
            int number = 0;
            int.TryParse(Console.ReadLine(), out number);
            for (int i = 0; i < number; ++i)
            {
                terminals.Add(CreateTerminal());
            }
            Airport airport = new Airport(name, terminals);
            return airport;
        }
        public static Flight CreateFlight()
        {
            Console.Clear();
            DateTime dateTime;
            string name = "";
            string airline = "";
            Flight.FlightStatus status = Flight.FlightStatus.Unknown;
            Console.WriteLine("Creating flight : ");

            Console.Write("Enter date & time of flight arrival : ");
            DateTime.TryParse(Console.ReadLine(), out dateTime);

            Console.Write("Enter name of flight : ");
            name = Console.ReadLine()!;

            Console.Write("Enter airline which is using in your flight : ");
            airline = Console.ReadLine()!;

            Console.Write("Enter flight status of your flight : \n" +
                "CheckIn = 1,\tGateClosed = 2,\nArrived = 3,\tDepartedAt = 4,\nUnknown = 5,\tCanceled = 6,\n" +
                "ExpectedAt = 7,\tDelayed = 8\n,InFlight = 9\nYour answer : ");
            Flight.FlightStatus.TryParse(Console.ReadLine(), out status);
            Airport airport = CreateAirport();
            Airplane airplane = CreateAirplane();
            Flight flight = new Flight(dateTime, name, airline, status, airplane, airport);
            return flight;
        }
        public static List<Flight> AddDataToList()
        {
            Console.Clear();
            List<Flight> list = new List<Flight>();
            Console.Write("Adding data to list : \nHow many flights you need to create : ");
            int numberOfFlights = 0;
            int.TryParse(Console.ReadLine(), out numberOfFlights);
            for (int i = 0; i < numberOfFlights; ++i)
            {
                list.Add(CreateFlight());
            }
            return list;
        }

        public static void ActionOnFlight(List<Flight> flights, string ifNull, string messageWrite, string messageException, Action<int> action)
        {
            if (flights == null)
            {
                Console.WriteLine(ifNull);
                Thread.Sleep(200);
                return;
            }
            foreach (var item in flights)
            {
                Console.WriteLine($"ID : {item.ID + 1}, Name : {item.Name}");
            }
            int i = 0;
            Console.Write(messageWrite);
            int.TryParse(Console.ReadLine(), out i);
            try
            {
                action(i);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(messageException + ex.Message);
                Thread.Sleep(2000);
                return;
            }
        }
        public static void ShowFlights(List<Flight> flights)
        {
            if (flights == null)
            {
                Console.WriteLine("You have not any flights to delete them, please fill it firsly !");
                Thread.Sleep(2000);
                return;
            }
            foreach (var item in flights)
            {
                Console.WriteLine($"ID : {item.ID + 1}, Name : {item.Name}");
            }
        }
        public static void Run()
        {
            List<Flight> flights = new();
            int answer = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(ShowMenu());
                Console.Write("Enter number of option : ");
                int.TryParse(Console.ReadLine(), out answer);
                switch (answer)
                {
                    case 1:
                        {
                            flights = AddDataToList();
                            break;
                        }
                    case 2:
                        {
                            string ifNullMessage = "You have not any flights to update them, please fill it firsly !";
                            string messageWrite = "Enter which flight you want to update : ";
                            string messageException = "You have been putted wrong index !!!\n";

                            ActionOnFlight(flights, ifNullMessage, messageWrite, messageException, (i) => flights[i - 1] = CreateFlight());
                            break;
                        }
                    case 3:
                        {
                            string ifNullMessage = "You have not any flights to delete them, please fill it firsly !";
                            string messageWrite = "Enter which flight you want to delete : ";
                            string messageException = "You have been putted wrong index !!!\n";

                            ActionOnFlight(flights, ifNullMessage, messageWrite, messageException, (i) => flights.RemoveAt(i - 1));
                            break;
                        }
                    case 4:
                        {
                            int id = 0;
                            ShowFlights(flights);
                            Console.Write("Search flight in collection by ID : ");
                            int.TryParse(Console.ReadLine(), out id);
                            Flight flight = AirportInfo.Search(flights, id);
                            Console.WriteLine(flight + "\n\n");
                            break;
                        }
                    case 5:
                        {
                            int i = 0;
                            ShowFlights(flights);
                            Console.Write("In which flight you have an emergency : ");
                            int.TryParse(Console.ReadLine(), out i);
                            AirportInfo.Emergency(AirportInfo.EmergencyType.Evacuation, flights[i - 1]);
                            break;
                        }
                    case 6:
                        {
                            System.Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("You've been putted wrong answer !");
                            break;
                        }
                }
            } while (answer != 6);
        }
    }
}
