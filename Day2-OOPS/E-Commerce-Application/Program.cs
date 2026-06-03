using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_Application
{
    using E_Commerce_Application;

    class Program
    {
        static void Main()
        {
            Product prod = new Electronics(1, "Laptop", 50000);
            prod.DisplayProduct();
            prod.CalculateDiscount(10);

        }
    }


}
