using GoogleHashCode2019.Base;

namespace GoogleHashCode2019.Model
{
	public class SlideShowOutput : Output
	{
		public int TotalScore { get; set; }

		protected override string BuildOutputString()
		{
			return "hallo";
		}
	}
}