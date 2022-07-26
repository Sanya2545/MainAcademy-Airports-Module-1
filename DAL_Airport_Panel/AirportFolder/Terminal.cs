﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Airport_Panel
{
    public class Terminal : IAirport
    {
        private static int id = 0;
        public int ID
        {
            get { return generateId(); }
            init { }
        }
        public string Name { get; init; }
        public int [] Gates { get; set; }
        public Terminal(string name = "Unknown", int [] gates = null!)
        {
            ID = generateId();
            Name = name;
            if(gates == null)
            {
                Gates = new int [1];
            }
        }
        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < Gates.Length; ++i)
            {
                temp += $"\n\t\tGate #{i + 1} : {Gates[i]}";
            }
            return $"\n\tTerminal #{ID} {Name}\n{temp}";
        }
        private static int generateId()
        {
            return id += 1;
        }
    }
}
