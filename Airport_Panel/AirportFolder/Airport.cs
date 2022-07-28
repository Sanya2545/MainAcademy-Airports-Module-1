using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    public class Airport : IAirport
    {
        public string Name { get; init; }
        private List<Terminal> Terminals { get; set; }
        public Airport(string name = "Unknown", List<Terminal> terminals = null!)
        {
            Terminals = new List<Terminal>();
            Name = name;
            Terminals = terminals;

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
