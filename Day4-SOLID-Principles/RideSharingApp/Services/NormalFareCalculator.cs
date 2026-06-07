using RiderSharingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Services
{
 public class NormalFareCalculator:IFareCalculation
    {
        public double CalculateFare(double distance)
        {
            return distance*15;
        }
    }
}
