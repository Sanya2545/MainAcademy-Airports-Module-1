// See https://aka.ms/new-console-template for more information
namespace Airport_Panel
{
    public class Program
    {
        public static void Main (string [] args)
        {
            int[] numsOfGates = new int[5];
            for(int i = 0; i < numsOfGates.Length; ++i)
            {
                numsOfGates[i] = i + 1;
            }
            List<Terminal> terminals = new() { new Terminal("Europe direct.", numsOfGates), new Terminal("NewYork direct.", numsOfGates), new Terminal("Asia direct.", numsOfGates) };
            Airport airport = new("Fiumicino", terminals);
            List<Flight> flights = new() {new Flight(DateTime.Now, "NewYork - Roma", "NY Airlines", Flight.FlightStatus.InFlight, airport), new Flight(DateTime.Now, "Lisbon - Roma", "Ntr Airlines", Flight.FlightStatus.InFlight, airport) };
            Console.WriteLine("\nBefore changing data : ");
            foreach(Flight flight in flights)
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine("\nAfter changing data : ");
            foreach(Flight flight in flights)
            {
                if (flight.Name == "Lisbon - Roma")
                {
                    flight.ChangeData(DateTime.Now, "Amsterdam - Roma", "Turkish Airlines", Flight.FlightStatus.InFlight, airport);
                }
                Console.WriteLine(flight);
            }
            AirportInfo.Emergency(AirportInfo.EmergencyType.Fire);
        }
        
    }

}