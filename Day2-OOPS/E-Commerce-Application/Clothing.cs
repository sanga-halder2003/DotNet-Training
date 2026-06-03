using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_Application
{
     class Clothing:Product
    {
        public Clothing(int id, string name, double price) : base(id, name, price)
        {
            Price = price;
        }

        public override void CalculateDiscount(double discount)
        {
            Console.WriteLine($"Discount: {discount}%");
            double final_price = Price - (Price * 0.01);
            Console.WriteLine($"Final Price: {final_price}");
        }
    }
}
