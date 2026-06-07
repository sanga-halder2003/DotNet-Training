// OCP: Added Luxury Ride fare calculation
// without changing NormalFareCalculator.

using RiderSharingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Services
{
    public class LuxuryRideFareCalculator:IFareCalculation
    {
        public double CalculateFare(double distance)
        {
            return distance * 35;
        }
    }
}
