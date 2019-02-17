using System;
using System.IO;

namespace GoogleHashCode2019.Base
{
	public abstract class Output
	{
		protected string FixFileNameExt(string filePath)
		{
			if (string.Equals(Path.GetExtension(filePath), ".in", StringComparison.CurrentCultureIgnoreCase))
				return Path.ChangeExtension(filePath, ".out");

			return filePath;
		}

		public void Save(string filePath)
		{
			filePath = FixFileNameExt(filePath);

			File.WriteAllText(filePath, BuildOutputString());
		}

		protected abstract string BuildOutputString();
	}
}