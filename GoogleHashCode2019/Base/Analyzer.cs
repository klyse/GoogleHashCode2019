using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleHashCode2019.Base
{
    public abstract class Analyzer<TInput> where TInput : Input
    {
        protected StringBuilder Result;
        protected TInput Input;

        protected void Dump(string msg)
        {
            Result.AppendLine(msg);
        }

        protected void CountItem<T>(Dictionary<T, int> countStore, T item)
        {
            if (!countStore.TryGetValue(item, out var count))
                count = 0;
            countStore[item] = count + 1;
        }

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
