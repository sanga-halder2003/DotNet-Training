using System;
using System.Collections.Generic;				
public class DisplayEmployee
{
	public static void Main()
	{
		List<String> employees = new List<String>();
		employees.Add("Mean");
		employees.Add("Parbat");
		employees.Add("Sanga");
		
		foreach(var employee in employees)
		{
			Console.WriteLine(employee);
		}
		
	}
}
