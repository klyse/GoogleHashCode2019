using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleHashCode2018.Parser
{
	public static class InputParser
	{
		public static void ReadFile(string filePath)
		{
			var lines = File.ReadAllLines(filePath);
		}
	}
}
