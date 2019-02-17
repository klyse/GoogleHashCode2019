using System.IO;
using GoogleHashCode2019.Algorithms;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019
{
	public class Program
	{
		static void Main()
		{
			var pizzaInput = new PizzaInput().Load(Path.Combine(EnvironmentConstants.InputPath, "a_example.in"));

			var pizzaOutput = new PizzaSolver2().Execute(pizzaInput);

			pizzaOutput.Save(Path.Combine(EnvironmentConstants.OutputPath, pizzaInput.FileName));
		}
	}
}