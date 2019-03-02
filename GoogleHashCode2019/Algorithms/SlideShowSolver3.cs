using System.Collections.Generic;
using System.Linq;
using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
    public class SlideShowSolver3 : Solver<SlideShowInput, SlideShowOutput>
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

        private void BuildOutputGroup(List<Photo> photos)
        {
            var Tags = new TagMatrixV1(photos);
            var Used = new HashSet<Photo>();

            if (Output.Photos.Count == 0)
            {
                Output.Photos.Add(photos[0]);
                Used.Add(photos[0]);
            }

            var currentPhoto = Output.Photos[Output.Photos.Count - 1];

            while (Used.Count < photos.Count)
            {
                Photo bestMatch = null;
                int bestScore = 0;
                foreach (var tag in currentPhoto.Tags)
                {
                    var match = Tags.Tags[tag];
                    foreach (var photo in match)
                        if (!Used.Contains(photo))
                        {
                            var score = photo.GetScore(photo);
                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestMatch = photo;
                            }

                            if (bestMatch != null)
                                break;
                        }
                }
                if (bestMatch == null)
                    foreach (var photo in photos)
                        if (!Used.Contains(photo))
                        {
                            bestMatch = photo;
                            break;
                        }
                Output.Photos.Add(bestMatch);
                Used.Add(bestMatch);
                currentPhoto = bestMatch;
            }
        }

        private void BuildOutput()
        {
            var Tags = new TagMatrixV1(Work.Photos);
            var Used = new HashSet<Photo>();
            var currentPhoto = Work.Photos[0];
                Output.Photos.Add(currentPhoto);
                Used.Add(currentPhoto);

            while (Used.Count < Work.Photos.Count)
            {
                Photo bestMatch = null;
                int bestScore = 0;
                foreach (var tag in currentPhoto.Tags)
                {
                    var match = Tags.TagsSortedCount[tag];
                    foreach (var photo in match)
                        if (!Used.Contains(photo))
                        {
                            var score = currentPhoto.GetScore(photo);
                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestMatch = photo;
                            }
                        }

                    if (bestMatch != null)
                        break;
                }

                if (bestMatch == null)
                    foreach (var photo in Work.Photos)
                        if (!Used.Contains(photo))
                        {
                            bestMatch = photo;
                            break;
                        }

                Output.Photos.Add(bestMatch);
                Used.Add(bestMatch);
                currentPhoto = bestMatch;
            }
        }

        protected override void Solve()
        {
            CombineVertical();

            BuildOutput();

        }
    }
}