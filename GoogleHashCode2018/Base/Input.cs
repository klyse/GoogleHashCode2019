using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GoogleHashCode2018.Base
{
    public abstract class Input<T>
    {
        protected string[] ParseParamLineString(string line)
        {
            return line.Split(' ');
        }
        protected int[] ParseParamLineInt(string line)
        {
            return ParseParamLineString(line).Select(int.Parse).ToArray();
        }

        public T Load(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return Parse(lines);
        }

        public abstract T Parse(string[] input);
    }
}
