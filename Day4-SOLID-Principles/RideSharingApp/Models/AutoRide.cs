using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Models
{
    public class AutoRide : Ride
    {
        public override void RideDetails()
        {
            Console.WriteLine("Auto Ride Booked");
        }
    }
}
