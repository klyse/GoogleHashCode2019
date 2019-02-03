using GoogleHashCode2018.Base;
using GoogleHashCode2018.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode2018.Algorithms
{
    public class PizzaSolver1 : Solver<PizzaInput, PizzaOutput>
    {
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
            var rareCellType = FindCellTypeLowerCount();



        }
    }
}
