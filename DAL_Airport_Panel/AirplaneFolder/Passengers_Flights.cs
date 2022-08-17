using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Airport_Panel.AirplaneFolder
{
    public class Passengers_Flights
    {
        List<int> passengersIDs;
        List<Passenger> passengers;
        public Passengers_Flights(List<Passenger> passengers, List<int> passengersIDs)
        {
            if (passengers == null || passengersIDs == null)
            {
                this.passengers = new List<Passenger>();
                this.passengersIDs = new List<int>();
            }
            else
            {
                this.passengers = passengers;
                this.passengersIDs = passengersIDs;
            }

        }
    }
}
