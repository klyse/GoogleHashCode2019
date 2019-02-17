using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;
using NeoMatrix;

namespace GoogleHashCode2019.Algorithms
{
	public class PizzaSolver2 : Solver<PizzaInput, PizzaOutput>
	{
		protected override void Solve()
		{
			for (var x = Input.MinIngredients; x < Input.MaxCells; ++x)
			for (var y = Input.MinIngredients; y < Input.MaxCells; ++y)
			for (var i = 0; i < Input.Matrix.Rows - x + 1; ++i)
			for (var j = 0; j < Input.Matrix.Columns - y + 1; ++j)
			{
				if (x * y > Input.MaxCells)
					continue;

				var box = Input.Matrix.GetFromRegion(Region.FromTopLeft(i, j, x, y));

				var slice = PizzaOutput.Slice.CreateSlice(i, j, box);

				if (slice.IsValid())
				{
					Output.AddSlice(slice);
				}
			}

			var slices = Output.Result.OrderByDescending(c => c.Score).ToList();

			Output.Result.Clear();

			foreach (var slice in slices)
			{
				if (!Output.Result.Any(c => c.Rect.IntersectsWith(slice.Rect)))
				{
					Output.AddSlice(slice);
				}
			}
		}
	}
}