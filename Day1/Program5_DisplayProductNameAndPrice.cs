using System;
using System.Collections.Generic;				
public class DisplayProductNameAndPrice
{
	public static void Main()
	{
		Dictionary<string,int> product = new Dictionary<string,int>();
		product.Add("Mouse",900);
		product.Add("Keyboard",1000);
		
		foreach(var prod in product)
		{
			Console.WriteLine($"{prod.Key} - {prod.Value}");
		}
		
		
		
	}
}
