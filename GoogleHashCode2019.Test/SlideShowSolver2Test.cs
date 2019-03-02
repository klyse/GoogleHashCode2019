using System;
using System.IO;
using GoogleHashCode2019.Algorithms;
using NUnit.Framework;

namespace GoogleHashCode2019.Test
{
	public class SlideShowSolver2Test
	{
		[Test]
		[TestCase("a_example.txt")]
		[TestCase("b_lovely_landscapes.txt")]
		[TestCase("c_memorable_moments.txt")]
		[TestCase("d_pet_pictures.txt")]
		[TestCase("e_shiny_selfies.txt")]
		public void SlideShowSolver2(string example)
		{
			var output = new SlideShowSolver2().ExecuteAndSave(Path.Combine(EnvironmentConstants.InputPath, example), EnvironmentConstants.OutputPath, true);

			Console.WriteLine($"Total Score: {output.TotalScore}");

			Assert.Pass();
		}
	}
}