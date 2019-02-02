using System;
using System.IO;
using GoogleHashCode2018.Model;

namespace GoogleHashCode2018
{
	public class Program
	{
		static void Main(string[] args)
		{
            var pizzaInput = new PizzaInput().Load(Path.Combine(EnvironmentConstants.InputPath, "a_example.in"));

            Console.WriteLine($"{pizzaInput.MaxCells} / {pizzaInput.MinIngredients}");
            Console.ReadLine();
		}
	}
}