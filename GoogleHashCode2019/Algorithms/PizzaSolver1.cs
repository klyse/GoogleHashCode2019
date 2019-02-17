using System.Linq;
using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
	public class PizzaSolver1 : Solver<PizzaInput, PizzaOutput>
	{
		private PizzaInput.CellType FindCellTypeLowerCount()
		{
			var tomatoCount = Input.Matrix.GetFlat().Count(c => c == PizzaInput.CellType.Tomato);
			var mushroomCount = Input.Matrix.Columns * Input.Matrix.Rows - tomatoCount;

			return tomatoCount < mushroomCount ? PizzaInput.CellType.Tomato : PizzaInput.CellType.Mushroom;
		}

		protected override void Solve()
		{
			var rareCellType = FindCellTypeLowerCount();

			for (var r = 0; r < Input.Matrix.Rows; r++)
			for (var c = 0; c < Input.Matrix.Columns; c++)
			{
				// Found the first rare item, start a new slice
				if (Input.Matrix[r, c] == rareCellType)
				{
					//var slice = new PizzaOutput.Slice {FromRow = r, ToRow = r, FromColumn = c, ToColumn = c};
				}
			}
		}
	}
}