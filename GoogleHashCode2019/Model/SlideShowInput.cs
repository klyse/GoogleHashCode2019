using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode2019.Base;

namespace GoogleHashCode2019.Model
{
	public enum Orientation
	{
		Horizontal,
		Vertical
	}

	public class Photo
	{
		private HashSet<string> _tags = new HashSet<string>();
		public int Id { get; set; }
		public Orientation Orientation { get; set; }

		public HashSet<string> Tags
		{
			get
			{
				var allTags = _tags;
				if (AdditionalPhoto != null)
				{
					foreach (var additionalPhotoTag in AdditionalPhoto.Tags)
					{
						allTags.Add(additionalPhotoTag);
					}
				}

				return allTags;
			}
		}

		public Photo AdditionalPhoto { get; set; }
		public bool HasAdditionalPhoto => AdditionalPhoto != null;

		public void AddPhoto(Photo photo)
		{
			if (Orientation == Orientation.Vertical &&
				photo.Orientation == Orientation.Vertical)
			{
				AdditionalPhoto = photo;
			}
			else
			{
				throw new Exception("Can not add a Horizontal photo.");
			}
		}

		public static Photo CreatePhoto(string input, int id)
		{
			var photo = new Photo();

			photo.Id = id;
			var photoProp = input.Split(' ');

			switch (photoProp.First())
			{
				case "H":
					photo.Orientation = Orientation.Horizontal;
					break;
				case "V":
					photo.Orientation = Orientation.Vertical;
					break;
				default:
					throw new Exception("Does not match pattern V/H.");
			}

			foreach (var tag in photoProp.Skip(2))
			{
				photo.Tags.Add(tag);
			}

			return photo;
		}

		public int GetScore(Photo photo)
		{
			var except1 = photo.Tags.Except(Tags).ToList();
			var except2 = Tags.Except(photo.Tags).ToList();

			var s1 = except1.Count;
			var s2 = except2.Count;
			var same = photo.Tags.Count - except1.Count;

			return Math.Min(Math.Min(s1, s2), same);
		}

		public int GetMaxScore(Photo photo)
		{
			var tagsCnt = Math.Min(photo.Tags.Count, Tags.Count);

			return tagsCnt / 2;
		}

		public string GetPhotoString()
		{
			if (HasAdditionalPhoto)
				return $"{Id} {AdditionalPhoto.Id}";

			return $"{Id}";
		}

        public override string ToString()
        {
            return GetPhotoString();
        }
    }

	public class SlideShowInput : Input
	{
		public List<Photo> Photos { get; set; } = new List<Photo>();

		protected override void Parse(string[] input)
		{
			var index = 0;
			foreach (var inputLine in input.Skip(1))
			{
				var photo = Photo.CreatePhoto(inputLine, index);
				Photos.Add(photo);
				index++;
			}
		}
	}
}