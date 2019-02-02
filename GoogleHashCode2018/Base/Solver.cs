using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode2018.Base
{
    public abstract class Solver<I, O> where O : Output
    {
        protected abstract O Solve(I input);

        public O Execute(I input)
        {
            return Solve(input);
        }
    }
}
