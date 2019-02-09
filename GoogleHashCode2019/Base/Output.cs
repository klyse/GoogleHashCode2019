using System;
using System.IO;

namespace GoogleHashCode2019.Base
{
    public abstract class Output
    {
        protected string FixFileNameExt(string filePath)
        {
            if (string.Compare(Path.GetExtension(filePath), ".in", true) == 0)
                return Path.ChangeExtension(filePath, ".out");

            return filePath;
        }

        public void Save(String filePath)
        {
            filePath = FixFileNameExt(filePath);

            File.WriteAllText(filePath, BuildOutputString());
        }

        protected abstract string BuildOutputString();
    }
}
