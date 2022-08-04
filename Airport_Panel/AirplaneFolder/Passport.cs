using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Airport_Panel.AirplaneFolder.Passenger;

namespace Airport_Panel.AirplaneFolder
{
    public class Passport
    {
        public enum sex { Male = 1, Female }
        private static int id = 0;
        public int ID
        {
            get { return generateId(); }
            set { }
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nationality { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public sex Sex { get; set; }
        public Passport(int iD = 0, string firstName = "Ivan", string secondName = "Ivanov", string nationality = "Ukrainian", DateOnly dateOfBirth = default, sex sex = sex.Male)
        {
            ID = iD;
            FirstName = firstName;
            SecondName = secondName;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
            Sex = sex;
        }
        public override string ToString()
        {
            return $"\n\tPassport #{ID},\n\tFirst Name : {FirstName},\n\tSecond Name : {SecondName},\n\t" +
                $"Nationality : {Nationality},\n\tDate Of Birth : {DateOfBirth},\n\tSex : {Sex}";
        }
        private static int generateId()
        {
            return id += 1;
        }
    }
}
