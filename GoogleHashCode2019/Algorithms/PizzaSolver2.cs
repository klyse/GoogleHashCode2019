using System.Collections.Generic;
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
			for (var i = 0; i < Input.Matrix.Rows; ++i)
			for (var j = 0; j < Input.Matrix.Columns - 1; ++j)
			{
				var box = Input.Matrix.GetFromRegion(Region.FromTopLeft(i, j, 1, 2));

				var slice = PizzaOutput.Slice.CreateSlice(i, j, box);

				if (slice.IsValid())
				{
					Output.AddSlice(slice);
				}
			}
		}
	}
}