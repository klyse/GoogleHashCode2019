using System.IO;
using System.Reflection;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace GoogleHashCode2018.Test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}


		[Test]
		public void CheckIfEnvironmentVariableIsSet()
		{
			Assert.IsNotNull(EnvironmentConstants.DataPath);
		}

		[Test]
		public void Test1()
		{
			var x = EnvironmentConstants.DataPath;
			var readAllLines = File.ReadAllLines(EnvironmentConstants.DataPath + "/input/a_example.in");

			File.WriteAllLines(EnvironmentConstants.DataPath + "/output/a", readAllLines);

			Assert.Pass();
		}
	}
}