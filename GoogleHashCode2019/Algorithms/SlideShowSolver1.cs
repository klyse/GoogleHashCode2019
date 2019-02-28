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

			var p0 = Photo.CreatePhoto("H 3 cat beach sun", 0);
			var p1 = Photo.CreatePhoto("V 2 selfie smile", 1);
			var p2 = Photo.CreatePhoto("V 2 garden selfie", 2);
			var p3 = Photo.CreatePhoto("H 2 garden cat", 3);

			Output.Photos.Add(p0);
			Output.Photos.Add(p3);
			p1.AddPhoto(p2);
			Output.Photos.Add(p1);
		}
	}
}