// OCP + Polymorphism:
// New ride type added without modifying Ride class.

using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Models
{
    public class BikeRide : Ride
    {
        public override void RideDetails()
        {
            Console.WriteLine("Bike Ride Booked");
        }
    }
}
