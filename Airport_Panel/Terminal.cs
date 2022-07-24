using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    public class Terminal
    {
        private static int id = 0;
        public int ID
        {
            get { return generateId(); }
            init {}
        }
        string Name { get; set; }
        public int[] Gates { get; set; }
        public Terminal(string name = "Unknown", int[] gates = null)
        {
            ID = generateId();
            Name = name;
            Gates = gates;
        }
        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < Gates.Length; ++i)
            {
                temp += $"\n\t\tGate #{i + 1} : {Gates[i]}";
            }
            return $"\n\tTerminal #{ID} {Name}{temp}";
        }
        private static int generateId()
        {
            return id += 1;
        }
    }
}
