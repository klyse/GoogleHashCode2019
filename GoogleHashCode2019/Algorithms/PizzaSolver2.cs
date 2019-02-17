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
			for (var x = 1; x < Input.MaxCells; ++x)
			for (var y = 1; y < Input.MaxCells; ++y)
			for (var i = 0; i < Input.Matrix.Rows - x + 1; ++i)
			for (var j = 0; j < Input.Matrix.Columns - y + 1; ++j)
			{
				if (x * y > Input.MaxCells ||
					x * y * 2 < Input.MinIngredients)
					continue;

				var box = Input.Matrix.GetFromRegion(Region.FromTopLeft(i, j, x, y));

				var slice = PizzaOutput.Slice.CreateSlice(i, j, box);

				if (slice.IsValid())
				{
					Output.AddSlice(slice);
				}
			}

			var slices = Output.Result.OrderByDescending(c => c.Score).Take(200000).ToList();
			
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