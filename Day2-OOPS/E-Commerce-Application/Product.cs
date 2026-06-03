using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce_Application
{
    abstract class Product
    {
        public int ProductId;
        public string ProductName;
        private double price;

        public double Price
        {
            get {  return price;}
            protected set { price = value; }
        }
       
        // constructor
        public Product(int prodId, string productName, double price)
        {
            ProductId = prodId;
            ProductName = productName;
            Price = price;
        }

        // abstract method

        public abstract void CalculateDiscount(double discount);

        //method

        public void DisplayProduct()
        {
            Console.WriteLine($"ProductName: {ProductName}");
            Console.WriteLine($"Orijinal Price: {Price}");
        }



    }
}
