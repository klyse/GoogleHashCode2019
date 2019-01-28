using System;

namespace GoogleHashCode2018
{
	public static class EnvironmentConstants
	{
		public static string EnvironmentVariable { get; } = "CodeInput";
		public static string DataPath => Environment.GetEnvironmentVariable(EnvironmentVariable);
	}
}