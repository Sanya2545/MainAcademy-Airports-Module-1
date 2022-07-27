using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    public static class AirportInfo
    {
        public enum EmergencyType { Evacuation, Fire}
        public static Flight Search(List<Flight> flights, int id = 0)
        {
            Flight flight = flights.Where(i => i.ID == id).FirstOrDefault()!;
            if(flight != null)
            {
                Console.WriteLine("Searching by ID succeed !");
                return flight;
            }
            else
            {
                throw new NullReferenceException("The flight you were searching is null !");
            }
        }
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
        public static void Emergency(EmergencyType emergency = EmergencyType.Evacuation)
        {
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
