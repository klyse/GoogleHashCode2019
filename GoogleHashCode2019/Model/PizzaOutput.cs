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

			public int FromRow { get; set; }
			public int FromColumn { get; set; }
			public int ToRow => FromRow + SliceMatrix.Rows;
			public int ToColumn => FromColumn + SliceMatrix.Columns;

			public int Score => SliceMatrix.Columns * SliceMatrix.Rows;

			public Matrix<PizzaInput.CellType> SliceMatrix { get; set; }

			public static Slice CreateSlice(int row, int column, Matrix<PizzaInput.CellType> mat)
			{
				var slice = new Slice();

				slice.SliceMatrix = mat;
				slice.FromRow = row;
				slice.FromColumn = column;

				return slice;
			}

			public bool IsValid()
			{
				var totalCount = SliceMatrix.Columns * SliceMatrix.Rows;
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
			if (!slice.IsValid())
				throw new Exception("Slice is not valid");

			Result.Add(slice);
		}

		protected override string BuildOutputString()
		{
			var output = new StringBuilder();
			output.AppendLine($"{Result.Count}");
			foreach (var item in Result)
				output.AppendLine($"{item.FromRow} {item.ToRow} {item.FromColumn} {item.ToColumn}");

			return output.ToString();
		}
	}
}