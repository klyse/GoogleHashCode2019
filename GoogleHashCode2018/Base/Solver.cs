using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode2018.Base
{
    public abstract class Solver<I, O> where O : Output, new()
    {
        protected I Input;
        protected O Output;

        protected abstract O Solve();

        public O Execute(I input)
        {
            Input = input;
            Output = new O();
            Solve();

            return Output;
        }
    }
}
