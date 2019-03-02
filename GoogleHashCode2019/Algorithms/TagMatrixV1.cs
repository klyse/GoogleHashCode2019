using GoogleHashCode2019.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode2019.Algorithms
{
    class TagMatrixV1
    {
        // private Dictionary<string, List<Photo>> Matrix = new Dictionary<string, List<Photo>>();
        public Dictionary<string, HashSet<Photo>> Tags = new Dictionary<string, HashSet<Photo>>();
        public Dictionary<string, List<Photo>> TagsSortedCount = new Dictionary<string, List<Photo>>();

        /*
        private string GetKey(string tag1, string tag2)
        {
            KeyBuilder.Length = 0;
            KeyBuilder.Append(tag1).Append('|').Append(tag2);
            return KeyBuilder.ToString();
        }

        private void AddAinB(HashSet<Photo> photos1, HashSet<Photo> photos2, List<Photo> output)
        {
            foreach (var photo in photos1)
                if (photos2.Contains(photo))
                    output.Add(photo);
        }
        */

        public TagMatrixV1(SlideShowInput input)
        {
            InitTags(input.Photos);

            // InitMatrix();
        }

        public TagMatrixV1(List<Photo> photos)
        {
            InitTags(photos);

            // InitMatrix();
        }

        /*
        private void InitMatrix()
        {
            foreach (var photo in Input.Photos)
            {
                foreach(tag)

                var photos1 = Tags[tag1];
                foreach (var tag2 in Tags.Keys)
                {
                    var photos2 = Tags[tag2];
                    var intersect = new List<Photo>();
                    AddAinB(photos1, photos2, intersect);
                    AddAinB(photos2, photos1, intersect);
                    Matrix[GetKey(tag1, tag2)] = intersect;
                }
            }
        }
        */

        /*
        private void InitMatrix()
        {
            foreach (var tag1 in Tags.Keys)
            {
                var photos1 = Tags[tag1];
                foreach (var tag2 in Tags.Keys)
                {
                    var photos2 = Tags[tag2];
                    var intersect = new List<Photo>();
                    AddAinB(photos1, photos2, intersect);
                    AddAinB(photos2, photos1, intersect);
                    Matrix[GetKey(tag1, tag2)] = intersect;
                }
            }
        }
        */

        private void InitTags(List<Photo> photoList)
        {
            foreach (var photo in photoList)
                foreach (var tag in photo.Tags)
                {
                    HashSet<Photo> photos;
                    if (!Tags.TryGetValue(tag, out photos))
                    {
                        photos = new HashSet<Photo>();
                        Tags.Add(tag, photos);
                    }

                    photos.Add(photo);
                }

            foreach (var tag in Tags)
                TagsSortedCount[tag.Key] = tag.Value.OrderBy(q => Tags.Count).ToList();
        }

        /*
        public List<Photo> GetPhotos(string tag1, string tag2)
        {
            List<Photo> result = null;
            Matrix.TryGetValue(GetKey(tag1, tag2), out result);
            return result;
        }
        */
    }
}
