using System.IO;
using GoogleHashCode2019.Algorithms;
using GoogleHashCode2019.Model;
using NUnit.Framework;

namespace GoogleHashCode2019.Test
{
	public class PizzaSolver1Test
	{
		[Test]
		[TestCase("a_example.in")]
		[TestCase("b_small.in")]
		[TestCase("c_medium.in")]
		[TestCase("d_big.in")]
		public void PizzaSolver1(string example)
		{
			var pizzaInput = new PizzaInput().Load(Path.Combine(EnvironmentConstants.InputPath, example));

			var pizzaOutput = new PizzaSolver1().Execute(pizzaInput);

			pizzaOutput.Save(Path.Combine(EnvironmentConstants.OutputPath, "PizzaSolver1", pizzaInput.FileName));

			Assert.Pass();
		}
	}
}