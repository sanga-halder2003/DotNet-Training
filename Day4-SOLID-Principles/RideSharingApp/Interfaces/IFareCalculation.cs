using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Interfaces
{
    public interface IFareCalculation
    {
        double CalculateFare(double distance);
    }
}
