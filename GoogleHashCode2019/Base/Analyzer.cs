using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode2019.Base
{
    public abstract class Analyzer<TInput> where TInput : Input
    {
        protected StringBuilder Result;
        protected TInput Input;

        public string Execute(TInput input)
        {
            Input = input;
            Result = new StringBuilder();

            Analyze();

            return Result.ToString();
        }

        protected abstract void Analyze();
    }
}
