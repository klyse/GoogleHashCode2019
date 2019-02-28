using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
	public class SlideShowSolver1 : Solver<SlideShowInput, SlideShowOutput>
	{
		protected override void Solve()
		{
			Output.Photos.Add(Photo.CreatePhoto("H 3 a b c", 0));
			Output.Photos.Add(Photo.CreatePhoto("H 3 q b c", 0));
			Output.Photos.Add(Photo.CreatePhoto("H 3 a b c", 0));
		}
	}
}