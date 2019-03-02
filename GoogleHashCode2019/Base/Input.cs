using System.IO;
using System.Linq;

namespace GoogleHashCode2019.Base
{
    public abstract class Input
    {
        public string FileName { get; private set; }

        protected string[] ParseParamLineString(string line)
        {
            return line.Split(' ');
        }

        protected int[] ParseParamLineInt(string line)
        {
            return ParseParamLineString(line).Select(int.Parse).ToArray();
        }

        public void Load(string filePath)
        {
            FileName = Path.GetFileName(filePath);
            var lines = File.ReadAllLines(filePath);
            Parse(lines);
        }

        protected abstract void Parse(string[] input);
    }
}