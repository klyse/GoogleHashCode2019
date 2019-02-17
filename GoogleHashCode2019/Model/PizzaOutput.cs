using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleHashCode2019.Base;
using NeoMatrix;

namespace GoogleHashCode2019.Model
{
	public class PizzaOutput : Output
	{
		public class Slice
		{
			public static int MinIngredients { get; set; }
			public static int MaxCells { get; set; }

			public int RowFrom { get; set; }
			public int ColumnFrom { get; set; }
			public int RowTo => RowFrom + SliceMatrix.Rows - 1;
			public int ColumnTo => ColumnFrom + SliceMatrix.Columns - 1;

			public int Score => SliceMatrix.TotalCount;

			public Matrix<PizzaInput.CellType> SliceMatrix { get; set; }

			public static Slice CreateSlice(int fromRow, int fromColumn, Matrix<PizzaInput.CellType> mat)
			{
				var slice = new Slice();

				slice.SliceMatrix = mat;
				slice.RowFrom = fromRow;
				slice.ColumnFrom = fromColumn;

				return slice;
			}

			public bool IsValid()
			{
				var totalCount = SliceMatrix.TotalCount;
				if (totalCount > MaxCells)
					return false;

				var tom = SliceMatrix.GetFlat().Count(c => c == PizzaInput.CellType.Tomato);
				var mush = totalCount - tom;

				if (tom < MinIngredients || mush < MinIngredients)
					return false;

				return true;
			}
		}

		public readonly List<Slice> Result = new List<Slice>();

		public void AddSlice(Slice slice)
		{
			Result.Add(slice);
		}


		protected override string BuildOutputString()
		{
			var output = new StringBuilder();
			output.AppendLine($"{Result.Count}");
			foreach (var item in Result)
				output.AppendLine($"{item.RowFrom} {item.ColumnFrom} {item.RowTo} {item.ColumnTo}");

			return output.ToString();
		}
	}
}