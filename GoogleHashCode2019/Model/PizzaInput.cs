using System.Linq;
using GoogleHashCode2019.Base;

namespace GoogleHashCode2019.Model
{
	public class PizzaInput : Input<PizzaInput>
	{
		public enum CellType
		{
			Tomato,
			Mushroom
		}

		public int Columns { get; set; }
		public int Rows { get; set; }

		public int MinIngredients { get; set; }
		public int MaxCells { get; set; }

		public CellType[,] Matrix { get; set; }

		public override PizzaInput Parse(string[] input)
		{
			var descriptiveProps = ParseParamLineInt(input[0]);

			Rows = descriptiveProps.ElementAt(0);
			Columns = descriptiveProps.ElementAt(1);
			MinIngredients = descriptiveProps.ElementAt(2);
			MaxCells = descriptiveProps.ElementAt(3);

			Matrix = new CellType[Rows, Columns];

			for (var i = 1; i < input.Length; i++)
			{
				var row = i - 1;
				var rowData = input[i];
				for (var j = 0; j < rowData.Length; j++)
					if (rowData[j] == 'T')
						Matrix[row, j] = CellType.Tomato;
					else
						Matrix[row, j] = CellType.Mushroom;
			}

			return this;
		}
	}
}