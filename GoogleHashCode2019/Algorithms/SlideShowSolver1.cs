using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
	public class SlideShowSolver1 : Solver<SlideShowInput, SlideShowOutput>
	{
        private TagMatrix Tags;

		protected override void Solve()
		{
            Tags = new TagMatrix(Input);

            Output.Photos.Add(Photo.CreatePhoto("H 3 a b c", 0));
			Output.Photos.Add(Photo.CreatePhoto("H 3 q b c", 0));
			Output.Photos.Add(Photo.CreatePhoto("H 3 a b c", 0));
		}
	}
}