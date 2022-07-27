using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    public class Flight
    {
        private static int id = 0;
        public enum FlightStatus {CheckIn, GateClosed, Arrived, DepartedAt, Unknown, Canceled, ExpectedAt, Delayed, InFlight}
        public int ID
        {
            get { return generateId(); }
            init { }
        }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Airline { get; set; }
        public FlightStatus Status { get; set; }
        public Airport Airport { get; set; }

        public Flight(DateTime dateTime, string name = "Unknown", string airline = "Turkish Airlines",
            FlightStatus status = FlightStatus.Unknown, Airport airport = null)
        {
            Name = name;
            DateTime = dateTime;
            Airline = airline;
            Status = status;
            Airport = airport;
        }
        public bool ChangeData(DateTime dateTime, string name = "Unknown", string airline = "Turkish Airlines",
            FlightStatus status = FlightStatus.Unknown, Airport airport = null!)
        {
            try
            {
                if(VerifyData(name, airline, status, airport))
                {
                    DateTime = dateTime;
                    Name = name;
                    Airline = airline;
                    Status = status;
                    Airport = airport;
                }
                else
                {
                    throw new ArgumentException("Wrong data was passed as parameter !");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ChangeData Message : " + ex.Message + "\nStack Trace : " + ex.StackTrace);
                return false;
            }
        }

        public bool VerifyData(string name, string airline,
            FlightStatus status, Airport airport)
        {
            if(string.IsNullOrEmpty(name) || string .IsNullOrEmpty(airline))
                return false;
            name.Trim();
            airline.Trim();
            return !(airline == null || status == FlightStatus.Unknown || airport == null || airport.Name.Length < 1);
        }
        public void DeleteAllData()
        {
            Name = null!;
            DateTime = DateTime.MinValue;
            Airline = null!;
            Status = FlightStatus.Unknown;
            Airport = null!;
        }
        private static int generateId()
        {
            return id += 1;
        }
        public override string ToString()
        {
            return $"\nName : {Name},\nDateTime : {DateTime},\nAirline : {Airline},\nStatus : {Status},\nAirport : {Airport}";
        }
    }
}
