using System.IO;
using System.Linq;

namespace GoogleHashCode2019.Base
{
	public abstract class Input<T>
	{
		public string FileName { get; private set; }

		protected string[] ParseParamLineString(string line)
		{
			return line.Split(' ');
		}

		protected int[] ParseParamLineInt(string line)
		{
			return ParseParamLineString(line).Select(int.Parse).ToArray();
		}

		public T Load(string filePath)
		{
			FileName = Path.GetFileName(filePath);
			var lines = File.ReadAllLines(filePath);
			return Parse(lines);
		}

		public abstract T Parse(string[] input);
	}
}