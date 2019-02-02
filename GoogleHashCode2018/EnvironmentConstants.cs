using System;
using System.IO;

namespace GoogleHashCode2018
{
	public static class EnvironmentConstants
	{
		public static string EnvironmentVariable { get; } = "HashCodeWorkingDir";
		public static string DataPath => Environment.GetEnvironmentVariable(EnvironmentVariable);
		public static string InputPath => Path.Combine(DataPath, "Input");
		public static string OutputPath => Path.Combine(DataPath, "Output");

    }
}