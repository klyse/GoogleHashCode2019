using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;

namespace GoogleHashCode2019.Algorithms
{
    public class PizzaSolver1 : Solver<PizzaInput, PizzaOutput>
    {
        bool[,] Used;

        private (int tomatoCount, int mushroomCount) GetCellTypeCount()
        {
            int tomatoCount = 0;
            int mushroomCount = 0;

            for (int r = 0; r < Input.Rows; r++)
                for (int c = 0; c < Input.Columns; c++)
                    if (Input.Matrix[r, c] == PizzaInput.CellType.Tomato)
                        tomatoCount++;
                    else
                        mushroomCount++;
            return (tomatoCount, mushroomCount);
        }

        private PizzaInput.CellType FindCellTypeLowerCount()
        {
            var (tomatoCount, mushroomCount) = GetCellTypeCount();
            if (tomatoCount < mushroomCount)
                return PizzaInput.CellType.Tomato;
            return PizzaInput.CellType.Mushroom;
        }

        protected override void Solve()
        {
            Used = new bool[Input.Rows, Input.Columns];

            var rareCellType = FindCellTypeLowerCount();

            for (int r = 0; r < Input.Rows; r++)
                for (int c = 0; c < Input.Columns; c++)
                    // Found the first rare item, start a new slice
                    if (Input.Matrix[r, c] == rareCellType)
                    {
                        var slice = new PizzaOutput.Slice { FromRow = r, ToRow = r, FromColumn = c, ToColumn = c };
                    }
            {

            }
            {

            }

        }
    }
}
