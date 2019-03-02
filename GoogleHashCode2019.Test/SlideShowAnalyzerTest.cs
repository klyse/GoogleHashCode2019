using System;
using System.IO;
using GoogleHashCode2019.Algorithms;
using GoogleHashCode2019.Model;
using NUnit.Framework;

namespace GoogleHashCode2019.Test
{
	public class SlideShowAnalyzerTest
	{
		[Test]
		[TestCase("a_example.txt")]
		[TestCase("b_lovely_landscapes.txt")]
		[TestCase("c_memorable_moments.txt")]
		[TestCase("d_pet_pictures.txt")]
		[TestCase("e_shiny_selfies.txt")]
		public void SlideShowAnalyzer(string example)
		{
            new SlideShopAnalyzer().ExecuteAndSave(Path.Combine(EnvironmentConstants.InputPath, example), Path.Combine(EnvironmentConstants.OutputPath, "SlideShowAnalyzer"));

			Assert.Pass();
		}
	}
}