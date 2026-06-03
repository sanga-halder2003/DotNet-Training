using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_Application
{
     class Electronics:Product
    {
        public Electronics(int id, string name,double price):base(id,name,price)
        {
            Price = price;
        }

        public override void CalculateDiscount(double discount)
        {
            Console.WriteLine($"Discount: {discount}%");
            double final_price = Price - (Price * discount / 100);
            Console.WriteLine($"Final Price: {final_price}");
        }
    }
}
