using GoogleHashCode2019.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode2019.Algorithms
{
    class TagMatrix
    {
        private SlideShowInput Input;
        private StringBuilder KeyBuilder = new StringBuilder();
        // private Dictionary<string, List<Photo>> Matrix = new Dictionary<string, List<Photo>>();
        public Dictionary<string, HashSet<Photo>> Tags = new Dictionary<string, HashSet<Photo>>();

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

        public TagMatrix(SlideShowInput input)
        {
            Input = input;

            InitTags();

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

        private void InitTags()
        {
            foreach (var photo in Input.Photos)
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
