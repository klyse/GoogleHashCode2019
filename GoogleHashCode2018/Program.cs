using System;
using System.IO;
using GoogleHashCode2018.Algorithms;
using GoogleHashCode2018.Model;

namespace GoogleHashCode2018
{
	public class Program
	{
		static void Main(string[] args)
		{
            var pizzaInput = new PizzaInput().Load(Path.Combine(EnvironmentConstants.InputPath, "a_example.in"));

            var pizzaOutput = new PizzaSolver1().Execute(pizzaInput);

            pizzaOutput.Save(Path.Combine(EnvironmentConstants.OutputPath, pizzaInput.FileName));
		}
	}
}