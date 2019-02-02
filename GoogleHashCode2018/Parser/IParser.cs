using System.Collections.Generic;

namespace GoogleHashCode2018.Parser
{
	public interface IParser<out TParseType>
	{
		TParseType Parse(string filePath);
		TParseType Parse(ICollection<string> input);
	}
}