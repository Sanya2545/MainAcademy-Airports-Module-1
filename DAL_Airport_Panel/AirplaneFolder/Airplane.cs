using DAL_Airport_Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_DAL_Airport_Panel
{
    public class Airplane : IAirplane
    {
        public enum TypeOfPlane { Boeing = 1, Airbus};
        private static int id = 0;
        public int ID
        {
            get { return generateId(); }
            set { }
        }
        public string Name { get; set; }
        public TypeOfPlane Type { get; set; }
        public int NumOfSeats { get; set; }
        public Airplane(string name = "A320", TypeOfPlane type = TypeOfPlane.Airbus, int numOfSeats = 150)
        {
            Name = name;
            Type = type;
            NumOfSeats = numOfSeats;
        }

        private static int generateId()
        {
            return id += 1;
        }
        public override string ToString()
        {
            return $"ID : {ID}\nName : {Name}\nType of plane : {Type}\nNumOfSeats : {NumOfSeats}";
        }
    }
}
