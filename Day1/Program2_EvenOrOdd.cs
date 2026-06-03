using System;
					
public class Even_Odd
{
	public static void Main()
	{
		Console.WriteLine("Enter the number:");
		int num = Convert.ToInt32(Console.ReadLine()) ;
		if(num % 2 == 0)
		{
			Console.WriteLine("Even");
		}
		else
		{
			Console.WriteLine("Odd");
		}
		
	}
}
