using System.Collections.Generic;
using System.Linq;
using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
	public class SlideShowSolver1 : Solver<SlideShowInput, SlideShowOutput>
	{
		private TagMatrix Tags;

		protected override void Solve()
		{
			//Tags = new TagMatrix(Input);

			var verticalPhotos = Input.Photos.Where(c => c.Orientation == Orientation.Vertical).ToList();
			var combinedPhotos = new List<Photo>();


			combinedPhotos.AddRange(Input.Photos.Where(c => c.Orientation == Orientation.Horizontal));
			for (var i = 0; i < verticalPhotos.Count(); i += 2)
			{
				verticalPhotos[i].AddPhoto(verticalPhotos[i + 1]);
				combinedPhotos.Add(verticalPhotos[i]);
			}

			var orderedPhotos = combinedPhotos.OrderByDescending(c => c.Tags.Count);


			foreach (var orderedPhoto in orderedPhotos)
			{
				Output.Photos.Add(orderedPhoto);
			}
		}
	}
}