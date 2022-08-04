using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Airport_Panel.AirplaneFolder;
using Airport_Panel.InterfacesFolder;

namespace Airport_Panel
{
    public class Flight : IAirplane, ISubject
    {
        private List<IObserver> _observers;
        private FlightStatus _status;
        public enum Classes { Econom = 1, Comfort, ComfortPlus, Business}
        private static int id = 0;
        public enum FlightStatus { CheckIn = 1, GateClosed, Arrived, DepartedAt, Unknown, Canceled, ExpectedAt, Delayed, InFlight }
        public int ID
        {
            get { return generateId(); }
            set { }
        }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Airline { get; set; }
        public FlightStatus Status { get { return _status; }
            set
            {
                _status = value;
                Notify();
            }
        }
        public Airplane Plane { get; set; }
        public Airport Airport { get; set; }
        public Prices Prices { get; set; }
        public List<Passenger> Passengers { get; set; }
        public Flight(DateTime dateTime, string name = "Unknown", string airline = "Turkish Airlines",
            FlightStatus status = FlightStatus.Unknown, Airplane airplane = null!, Airport airport = null!, Prices prices = null!, List<Passenger> passengers = null!)
        {
            _observers = new List<IObserver>();
            Name = name;
            DateTime = dateTime;
            Airline = airline;
            Status = status;
            Plane = airplane;
            Airport = airport;
            Prices = prices;
            Passengers = passengers;
        }
        public bool ChangeData(DateTime dateTime, string name = "Unknown", string airline = "Turkish Airlines",
            FlightStatus status = FlightStatus.Unknown, Airplane airplane = null!, Airport airport = null!, Prices prices = null!, List<Passenger> passengers = null!)
        {
            try
            {
                if (VerifyData(name, airline, status, airplane, airport, prices, passengers))
                {
                    DateTime = dateTime;
                    Name = name;
                    Airline = airline;
                    Status = status;
                    Plane = airplane;
                    Airport = airport;
                    Prices = prices;
                    Passengers = passengers;
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
            FlightStatus status, Airplane airplane, Airport airport, Prices prices, List<Passenger> passengers)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(airline))
                return false;
            name.Trim();
            airline.Trim();
            return !(airline == null || status == FlightStatus.Unknown || airport == null || airport.Name.Length < 1
                || airplane == null || prices == null || passengers == null);
        }
        public void DeleteAllData()
        {
            Name = null!;
            DateTime = DateTime.MinValue;
            Airline = null!;
            Status = FlightStatus.Unknown;
            Plane = null!;
            Airport = null!;
            Prices = null!;
            Passengers = null!;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }

        private static int generateId()
        {
            return id += 1;
        }
        public override string ToString()
        {
            string temp = "";
            foreach (var item in Passengers)
            {
                temp += item;
            }
            return $"\nID : {ID}\nName : {Name},\nDateTime : {DateTime},\nAirline : {Airline},\n" +
                $"Status : {Status},\nAirport : {Airport},\n\tPrices : {Prices},\n\tPassengers : {temp}";
        }
    }
}
