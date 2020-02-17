using System;
using System.IO;
using GoogleHashCode2019.Algorithms;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019
{
	public class Program
	{
		static void Main()
		{
			Console.WriteLine("Google HashCode 2019");

			Console.WriteLine("by: VolkmarR & Klyse");

			Console.WriteLine();
			Console.WriteLine("--------------------------");
			Console.WriteLine("Problem: a_example:");

			var slideShowOutput = new SlideShowSolver1().ExecuteAndSave(Path.Combine(EnvironmentConstants.InputPath, "a_example.txt"), EnvironmentConstants.OutputPath, true);

			Console.WriteLine($"Best score: {slideShowOutput.TotalScore}");

			Console.WriteLine();
			Console.WriteLine("--------------------------");
			Console.WriteLine("Problem: b_lovely_landscapes:");

			slideShowOutput = new SlideShowSolver3().ExecuteAndSave(Path.Combine(EnvironmentConstants.InputPath, "b_lovely_landscapes.txt"), EnvironmentConstants.OutputPath, true);

			Console.WriteLine($"Best score: {slideShowOutput.TotalScore}");

			Console.WriteLine();
			Console.WriteLine("--------------------------");
			Console.WriteLine("Problem: c_memorable_moments:");

			slideShowOutput = new SlideShowSolver1().ExecuteAndSave(Path.Combine(EnvironmentConstants.InputPath, "c_memorable_moments.txt"), EnvironmentConstants.OutputPath, true);

			Console.WriteLine($"Best score: {slideShowOutput.TotalScore}");

			Console.WriteLine();
			Console.WriteLine("--------------------------");
			Console.WriteLine("Problem: d_pet_pictures:");

			slideShowOutput = new SlideShowSolver1().ExecuteAndSave(Path.Combine(EnvironmentConstants.InputPath, "d_pet_pictures.txt"), EnvironmentConstants.OutputPath, true);

			Console.WriteLine($"Best score: {slideShowOutput.TotalScore}");

			Console.WriteLine();
			Console.WriteLine("--------------------------");
			Console.WriteLine("Problem: e_shiny_selfies:");

			slideShowOutput = new SlideShowSolver4().ExecuteAndSave(Path.Combine(EnvironmentConstants.InputPath, "e_shiny_selfies.txt"), EnvironmentConstants.OutputPath, true);

			Console.WriteLine($"Best score: {slideShowOutput.TotalScore}");
			Console.WriteLine("(sorry original solution (292263 pt.) for this problem is not documented :/, this is as close as I got to reproduce it)");

			Console.ReadLine();
		}
	}
}
