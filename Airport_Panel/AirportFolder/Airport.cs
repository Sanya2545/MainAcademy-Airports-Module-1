using Airport_Panel.InterfacesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Panel.Flight;

namespace Airport_Panel
{
    public class Airport : IAirport, IObserver
    {
        public string Name { get; init; }
        private List<Terminal> Terminals { get; set; }
        public Airport(string name = "Unknown", List<Terminal> terminals = null!)
        {
            Terminals = new List<Terminal>();
            Name = name;
            Terminals = terminals;

        }
        public void Update(ISubject subject)
        {
            if (subject is Flight flight)
            {
                if (flight.Status == FlightStatus.Arrived)
                {
                    Console.WriteLine(String.Format("{0} Plane has been Arrived from airport {1}!", flight.Plane, Name));
                    Console.ReadKey();
                }
                else if (flight.Status == FlightStatus.DepartedAt)
                {
                    Console.WriteLine(
                        String.Format("{0} Plane has been Departed at the airport {1}!"),
                        flight.Plane,
                        Name);
                    Console.ReadKey();
                }
            }
        }
        public override string ToString()
        {
            string temp = "";
            foreach (Terminal item in Terminals)
            {
                temp += item.ToString();
            }
            return "\nName : " + Name + "\nTerminals : " + temp;
        }
    }
}
