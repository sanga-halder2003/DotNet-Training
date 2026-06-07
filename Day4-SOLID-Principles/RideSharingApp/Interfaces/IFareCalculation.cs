// OCP: New fare calculators can be added
// without modifying existing ones.

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
