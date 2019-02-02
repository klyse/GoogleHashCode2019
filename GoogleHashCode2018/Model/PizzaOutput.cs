using GoogleHashCode2018.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleHashCode2018.Model
{
    public class PizzaOutput : Output
    {
        public class Slice
        {
            public int FromRow { get; set; }
            public int ToRow { get; set; }
            public int FromColumn { get; set; }
            public int ToColumn { get; set; }
        }

        public List<Slice> Result = new List<Slice>();

        protected override string BuildOutputString()
        {
            var output = new StringBuilder();
            output.AppendLine($"{Result.Count}");
            foreach (var item in Result)
                output.AppendLine($"{item.FromRow} {item.ToRow} {item.FromColumn} {item.ToColumn}");

            return  output.ToString();
        }
    }
}
