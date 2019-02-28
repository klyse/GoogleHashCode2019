using System.Collections.Generic;
using System.Linq;
using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
	public class SlideShowSolver2 : Solver<SlideShowInput, SlideShowOutput>
	{
		private TagMatrix Tags;


        private void CombineVertical()
        {
            var verticalPhotos = Input.Photos.Where(c => c.Orientation == Orientation.Vertical).ToList();
            var combinedPhotos = new List<Photo>();


            combinedPhotos.AddRange(Input.Photos.Where(c => c.Orientation == Orientation.Horizontal));
            for (var i = 0; i < verticalPhotos.Count(); i += 2)
            {
                verticalPhotos[i].AddPhoto(verticalPhotos[i + 1]);
                combinedPhotos.Add(verticalPhotos[i]);
            }


            Work.Photos = combinedPhotos;
        }

        private void BuildOutput()
        {
            var orderedPhotos = Work.Photos.OrderByDescending(c => c.Tags.Count);

            foreach (var orderedPhoto in orderedPhotos)
            {
                Output.Photos.Add(orderedPhoto);
            }
        }

        protected override void Solve()
		{
            //Tags = new TagMatrix(Input);

            CombineVertical();

            BuildOutput();

        }
	}
}