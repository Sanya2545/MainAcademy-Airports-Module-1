using Airport_Panel.AirplaneFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Panel.Flight;

namespace Airport_Panel
{
    public class Menu
    {
        public enum MenuPoints { AddDataToList = 1, UpdateExistingData, DeleteAllData, SearchFlights, ShowAllFLights, EmergencyMessage, Exit };
        public static string ShowMenu()
        {
            return "1. Create flights\n" +
                   "2. Update existing data\n" +
                   "3. Delete all data\n" +
                   "4. Search Flight by ID, Date & Time, Airports\n" +
                   "5. Show all flights as a table\n" +
                   "6. Emergency message\n" +
                   "7. Exit";
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
            int.TryParse(Console.ReadLine()!, out typeOfPlane);//
            Console.Write("Enter the number of seats in your airplane : ");
            int.TryParse(Console.ReadLine(), out numOfSeats);//

            if (name == null || typeOfPlane < 1 || typeOfPlane > 2 || numOfSeats <= 6)
            {
                throw new ArgumentException("You've been putted wrong parameter !");
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
            string filePath = @"D:\MainAcademy\C# .NET\LabWorks\Module_1\Airport_Panel\Airport_Panel\bin\Debug\net6.0";
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

            Prices prices = new Prices(100, 150, 180, 250);
            List<Passenger> passengers = new() { new Passenger(5, new Passport(), Flight.Classes.Comfort) };
            Flight flight = new Flight(dateTime, name, airline, FlightStatus.Unknown, airplane, airport, prices, passengers);
            flight.OnArriveStatusEvent += Flight_OnArriveStatusEvent;
            flight.OnDepartStatusEvent += Flight_OnDepartStatusEvent;
            flight.Status = FlightStatus.DepartedAt;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamWriter sw = new StreamWriter(fs);
                string serializedFlight = JsonConvert.SerializeObject(flight);
                sw.WriteLine(serializedFlight);
                sw.Close();
            }
            Console.ReadKey();
            return flight;
        }

        private static void Flight_OnDepartStatusEvent(Flight flight)
        {
            Console.WriteLine($"The plane has been departed to the airport: {flight.Airport.Name}");
        }

        private static void Flight_OnArriveStatusEvent(Flight flight)
        {
            Console.WriteLine($"The plane has been arrived to the airport : ");
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

        //private static void Flight_OnChangeStatusEvent()
        //{
            
        //}

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
            MenuPoints answer = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(ShowMenu());
                Console.Write("Enter number of option : ");
                MenuPoints.TryParse(Console.ReadLine(), out answer);
                switch (answer)
                {
                    case MenuPoints.AddDataToList:
                        {
                            flights = AddDataToList();
                            Console.ReadKey();
                            break;
                        }
                    case MenuPoints.UpdateExistingData:
                        {
                            string ifNullMessage = "You have not any flights to update them, please fill it firsly !";
                            string messageWrite = "Enter which flight you want to update : ";
                            string messageException = "You have been putted wrong index !!!\n";

                            ActionOnFlight(flights, ifNullMessage, messageWrite, messageException, (i) => flights[i - 1] = CreateFlight());
                            Console.ReadKey();
                            break;
                        }
                    case MenuPoints.DeleteAllData:
                        {
                            string ifNullMessage = "You have not any flights to delete them, please fill it firsly !";
                            string messageWrite = "Enter which flight you want to delete : ";
                            string messageException = "You have been putted wrong index !!!\n";

                            ActionOnFlight(flights, ifNullMessage, messageWrite, messageException, (i) => flights.RemoveAt(i - 1));
                            Console.ReadKey();
                            break;
                        }
                    case MenuPoints.SearchFlights:
                        {
                            int id = 0;
                            ShowFlights(flights);
                            Console.Write("Search flight in collection by ID : ");
                            int.TryParse(Console.ReadLine(), out id);
                            Flight flight = AirportInfo.Search(flights, id);
                            Console.WriteLine(flight + "\n\n");
                            Console.ReadKey();
                            break;
                        }
                    case MenuPoints.ShowAllFLights:
                        {
                            foreach (var item in flights)
                            {
                                Console.WriteLine(item);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case MenuPoints.EmergencyMessage:
                        {
                            int i = 0;
                            ShowFlights(flights);
                            Console.Write("In which flight you have an emergency : ");
                            int.TryParse(Console.ReadLine(), out i);
                            AirportInfo.Emergency(AirportInfo.EmergencyType.Evacuation, flights[i + 1]);
                            Console.ReadKey();
                            break;
                        }
                    case MenuPoints.Exit:
                        {
                            System.Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("You've been putted wrong answer !");
                            Console.ReadKey();
                            break;
                        }
                }
            } while (answer != MenuPoints.Exit);
        }
    }
}
