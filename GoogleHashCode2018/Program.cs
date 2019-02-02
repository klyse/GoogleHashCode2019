using System;
using GoogleHashCode2018.Model;

namespace GoogleHashCode2018
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");


			var pizza = new Pizza().Parse(EnvironmentConstants.InputPath + "/a_example.in");

			Console.ReadLine();
		}
	}
}