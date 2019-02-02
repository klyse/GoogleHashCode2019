using System.Collections.Generic;
using System.IO;

namespace GoogleHashCode2018.Parser
{
	public abstract class Parser<TParseType> : IParser<TParseType>
	{
		public TParseType Parse(string filePath)
		{
			var lines = File.ReadAllLines(filePath);
			return Parse(lines);
		}

		public abstract TParseType Parse(ICollection<string> input);
	}
}