﻿using DAL_Airport_Panel.AirplaneFolder;
using DAL_DAL_Airport_Panel;
using System.Collections;


namespace DAL_Airport_Panel
{
    public class Flight : IAirplane, IComparable, IComparer
    {
        public string Message { get; set; }
        private static int id = 0;
        public int ID
        {
            get { return generateId(); }
            set { }
        }
        public delegate void EventDelegate(Flight flight);
        public event EventDelegate OnArriveStatusEvent;
        public event EventDelegate OnDepartStatusEvent;
        private void InvokeArriveStatusEvent()
        {
            OnArriveStatusEvent.Invoke(this);
        }
        private void InvokeDepartStatusEvent()
        {
            OnDepartStatusEvent.Invoke(this);
        }
        private FlightStatus _status;
        public enum Classes { Econom = 1, Comfort, ComfortPlus, Business }
        public enum FlightStatus { CheckIn = 1, GateClosed, Arrived, DepartedAt, Unknown, Canceled, ExpectedAt, Delayed, InFlight }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Airline { get; set; }

        public FlightStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                if (_status == FlightStatus.Arrived)
                {
                    InvokeArriveStatusEvent();
                }
                else if (_status == FlightStatus.DepartedAt)
                {
                    InvokeDepartStatusEvent();
                }
            }
        }
        public Airplane Plane { get; set; }
        public Airport Airport { get; set; }
        public Prices Prices { get; set; }
        public List<Passenger> Passengers { get; set; }
        public Flight(DateTime dateTime, string name = "Unknown", string airline = "Turkish Airlines",
            FlightStatus status = FlightStatus.Unknown, Airplane airplane = null!, Airport airport = null!, Prices prices = null!, List<Passenger> passengers = null!)
        {
            if(OnArriveStatusEvent == null)
            {
                OnArriveStatusEvent = DefaultOnArriveEvent;
            }
            if(OnDepartStatusEvent == null)
            {
                OnDepartStatusEvent = DefaultOnDepartEvent; 
            }
            Name = name;
            DateTime = dateTime;
            Airline = airline;
            Status = status;
            Plane = airplane;
            Airport = airport;
            Prices = prices;
            Passengers = passengers;
        }
        //Default methods to initialize events !
        #region Default Events
        public void DefaultOnArriveEvent(object o)
        {
            Message = "The function value was not assigned !";
        }
        public void DefaultOnDepartEvent(object o)
        {
            Message = "The function value was not assigned !";
        }
        #endregion
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

        //ID Generator
        private static int generateId()
        {
            return id += 1;
        }
        //CompareTo method 
        public int CompareTo(object? obj)
        {
            if (obj is Flight flight)
            {

                //If this object is greater than the next
                if (this.ID > flight.ID)
                {
                    return 1;  
                }
                //If this object is smaller than the next
                else if(this.ID < flight.ID)
                {
                    return -1;
                }
                //If null or equal
                return 0;
            }
            throw new ArgumentException("This object isn't a flight !");
        }
        public int Compare(object? x, object? y)
        {
            if(x is Flight f1 && y is Flight f2)
            {
                return f1.ID.CompareTo(f2.ID);
            }
            else
            {
                throw new ArgumentException("Outter, this object isn't a flight !");
            }
        }
        //ToString Method
        //Trouble with initialization of inner object - NullReference exception 
        public override string ToString()
        {
            string temp = "";
            foreach (var item in Passengers)
            {
                temp += item;
            }
            return $"\nID : {ID}\nName : {Name},\nDateTime : {DateTime},\nAirline : {Airline},\n" +
                $"Status : {Status},\n\tAirport : {Airport},\n\tPrices : {Prices},\n\tPassengers : {temp}";
        }

        
    }
}
