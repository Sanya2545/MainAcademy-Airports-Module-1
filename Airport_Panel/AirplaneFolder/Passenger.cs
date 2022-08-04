using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel.AirplaneFolder
{
    public class Passenger
    {
        

        private static int id = 0;
        public int ID
        {
            get { return generateId(); }
            set { }
        }
        public Passport Passport { get; set; }
        public Flight.Classes Class { get; set; }
        public Passenger(int iD = 0, Passport passport = null!, Flight.Classes classes = Flight.Classes.Econom)
        {
            ID = iD;
            Passport = passport;
            Class = classes;
        }
        public override string ToString()
        {
            return $"\n\tPassenger #{ID},\n\tPassport : {Passport},\n\tClass : {Class}";
        }
        private static int generateId()
        {
            return id += 1;
        }
    }
}
