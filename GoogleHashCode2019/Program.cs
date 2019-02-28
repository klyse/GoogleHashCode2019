using System.IO;
using GoogleHashCode2019.Algorithms;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019
{
	public class Program
	{
		static void Main()
		{
			var slideShowInput = new SlideShowInput().Load(Path.Combine(EnvironmentConstants.InputPath, "e_shiny_selfies.txt"));

            
            var slideShowOutput = new SlideShowSolver1().Execute(slideShowInput);

			slideShowOutput.Save(Path.Combine(EnvironmentConstants.OutputPath, slideShowInput.FileName));
		}
	}
}