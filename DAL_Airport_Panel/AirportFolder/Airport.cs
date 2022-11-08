using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL_Airport_Panel.Flight;

namespace DAL_Airport_Panel
{
    public class Airport : IAirport
    {
        public string Name { get; init; }
        private List<Terminal> Terminals { get; set; }
        public Airport(string name = "Unknown", List<Terminal> terminals = null!)
        {
            if(terminals == null)
            {
                Terminals = new List<Terminal>();
            }
            else
            {
                Terminals = terminals;
            }
            Name = name;

        }
        //
       

        public override string ToString()
        {
            string temp = "";
            foreach (Terminal item in Terminals)
            {
                temp += item.ToString();
            }
            return "\tAirport Name : " + Name + "\nTerminals : " + temp;
        }
    }
}
