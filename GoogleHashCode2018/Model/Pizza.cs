using System.Collections.Generic;
using System.Linq;
using GoogleHashCode2018.Parser;
using MathNet.Numerics.LinearAlgebra;

namespace GoogleHashCode2018.Model
{
	public class Pizza : Parser<Pizza>
	{
		public int Columns { get; set; }
		public int Rows { get; set; }

		public int MinIngredients { get; set; }
		public int MaxCells { get; set; }

		//public int<int> Matrix { get; set; }


		public override Pizza Parse(ICollection<string> input)
		{
			var descriptiveProps = input.First().Split(' ').Select(int.Parse).ToArray();

			Rows = descriptiveProps.ElementAt(0);
			Columns = descriptiveProps.ElementAt(1);
			MinIngredients = descriptiveProps.ElementAt(2);
			MaxCells = descriptiveProps.ElementAt(3);

			return this;
		}
	}
}