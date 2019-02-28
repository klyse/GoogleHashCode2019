using System.Collections.Generic;
using System.Text;
using GoogleHashCode2019.Base;

namespace GoogleHashCode2019.Model
{
	public class SlideShowOutput : Output
	{
		public int TotalScore { get; set; }

		public List<Photo> Photos { get; set; } = new List<Photo>();

		protected override string BuildOutputString()
		{
			var output = new StringBuilder();
			output.AppendLine($"{Photos.Count}");

			foreach (var photo in Photos)
			{
				output.Append(photo.Id);
			}

			return output.ToString();
		}
	}
}