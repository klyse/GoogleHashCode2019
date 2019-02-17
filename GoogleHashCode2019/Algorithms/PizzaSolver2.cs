using System.Linq;
using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;
using NeoMatrix;

namespace GoogleHashCode2019.Algorithms
{
	public class PizzaSolver2 : Solver<PizzaInput, PizzaOutput>
	{
		protected override void Solve()
		{
			for (var height = 1; height < Input.MaxCells; ++height)
			for (var width = 1; width < Input.MaxCells; ++width)
			for (var i = 0; i <= Input.Matrix.Rows - height; ++i)
			for (var j = 0; j <= Input.Matrix.Columns - width; ++j)
			{
				if (height * width > Input.MaxCells ||
					height * width < Input.MinIngredients * 2)
					continue;

				var box = Input.Matrix.GetFromRegion(Region.FromTopLeft(i, j, height, width));

				var slice = PizzaOutput.Slice.CreateSlice(i, j, box);

				if (slice.IsValid())
				{
					Output.AddSlice(slice);
				}
			}

			var slices = Output.Result.OrderByDescending(c => c.Score).ToList();

			Output.Result.Clear();

			var occupiedFields = new Matrix<bool>(Input.Matrix.Rows, Input.Matrix.Columns);

			foreach (var slice in slices)
			{
				var found = false;
				for (var i = slice.Rect.Top; i < slice.Rect.Bottom && !found; ++i)
				for (var j = slice.Rect.Left; j < slice.Rect.Right && !found; ++j)
				{
					if (occupiedFields[i, j])
					{
						found = true;
						continue;
					}

					occupiedFields[i, j] = true;
				}

				if (!found)
					Output.AddSlice(slice);
			}
		}
	}
}