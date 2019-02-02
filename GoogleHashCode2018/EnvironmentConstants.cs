using System;

namespace GoogleHashCode2018
{
	public static class EnvironmentConstants
	{
		public static string EnvironmentVariable { get; } = "HashCodeWorkingDir";
		public static string DataPath => Environment.GetEnvironmentVariable(EnvironmentVariable);
	}
}