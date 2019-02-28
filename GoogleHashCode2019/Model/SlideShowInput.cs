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
		public Orientation Orientation { get; set; }
		public List<string> Tags { get; set; } = new List<string>();

		public static Photo CreatePhoto(string input)
		{
			var photo = new Photo();
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
	}

	public class SlideShowInput : Input<SlideShowInput>
	{
		public List<Photo> Photos { get; set; }= new List<Photo>();

		public override SlideShowInput Parse(string[] input)
		{
			foreach (var inputLine in input.Skip(1))
			{
				var photo = Photo.CreatePhoto(inputLine);
				Photos.Add(photo);
			}

			return this;
		}
	}
}