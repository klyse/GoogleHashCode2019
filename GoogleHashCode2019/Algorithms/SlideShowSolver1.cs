using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
	public class SlideShowSolver1 : Solver<SlideShowInput, SlideShowOutput>
	{
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

		protected override void Solve()
		{
			CombineVertical();

			var orderedPhotos = Work.Photos.OrderByDescending(c => c.Tags.Count);

			var outPics = new List<Photo>();
			foreach (var orderedPhoto in orderedPhotos)
			{
				outPics.Add(orderedPhoto);
			}

			Work.Photos.Clear();

			Work.Photos.Add(outPics.First());
			outPics.RemoveAt(0);

			while (outPics.Count > 1)
			{
				var last = Work.Photos.Last();

				var bestResult = new Tuple<int, Photo>(0, null);
				bool foundAny = false;

				for (var i = 0; i < Math.Min(10, outPics.Count) || !foundAny; i++)
				{
					var comp = outPics.ElementAt(i);
					var maxScore = last.GetMaxScore(comp);
					var score = last.GetScore(comp);

					if (score > bestResult.Item1)
					{
						bestResult = new Tuple<int, Photo>(score, comp);
						foundAny = true;
					}

					if (score == maxScore)
						break;
				}

				if (bestResult.Item2 == null)
					continue;

				Work.Photos.Add(bestResult.Item2);
				outPics.Remove(bestResult.Item2);
			}

			Work.Photos.Add(outPics.ElementAt(0));

			foreach (var photo in Work.Photos)
			{
				Output.Photos.Add(photo);
			}
		}
	}
}