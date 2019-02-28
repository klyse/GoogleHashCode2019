using System;
using System.IO;
using GoogleHashCode2019.Algorithms;
using GoogleHashCode2019.Model;
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
			var slideShowInput = new SlideShowInput().Load(Path.Combine(EnvironmentConstants.InputPath, example));

			var slideShowOutput = new SlideShowSolver1().Execute(slideShowInput);

			slideShowOutput.Save(Path.Combine(EnvironmentConstants.OutputPath, "SlideShowSolver2", slideShowInput.FileName));

			Console.WriteLine($"Total Score: {slideShowOutput.TotalScore}");

			Assert.Pass();
		}
	}
}