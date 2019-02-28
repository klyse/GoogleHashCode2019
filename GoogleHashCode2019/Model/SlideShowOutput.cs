using System.Collections.Generic;
using System.Text;
using GoogleHashCode2019.Base;

namespace GoogleHashCode2019.Model
{
	public class SlideShowOutput : Output
	{
		public int TotalScore => CalcScore();

		public List<Photo> Photos { get; set; } = new List<Photo>();

		private int CalcScore()
		{
			var score = 0;
			for (var i = 0; i < Photos.Count-1; i++)
			{
				score += Photos[i].GetScore(Photos[i+1]);
			}

			return score;
		}

		protected override string BuildOutputString()
		{
			var output = new StringBuilder();
			output.AppendLine($"{Photos.Count}");

			foreach (var photo in Photos)
			{
				output.Append(photo.GetPhotoString());
			}

			return output.ToString();
		}
	}
}