using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleHashCode2019.Base
{
    public abstract class Analyzer<TInput> where TInput : Input, new()
    {
        protected StringBuilder Result;
        protected TInput Input;

        protected void Dump(string msg)
        {
            Result.AppendLine(msg).AppendLine();
        }

        protected void Dump<K, V>(string msg, IEnumerable<KeyValuePair<K, V>> data)
        {
            var index = 0;
            Result.AppendLine(msg);
            foreach (var item in data)
                Result.AppendLine($"{++index}) {item.Key} = {item.Value}");

            Result.AppendLine();
        }

        protected void CountItem<T>(Dictionary<T, int> countStore, T item)
        {
            if (!countStore.TryGetValue(item, out var count))
                count = 0;
            countStore[item] = count + 1;
        }

        protected void CountItems<T>(Dictionary<T, int> countStore, IEnumerable<T> items)
        {
            foreach (var item in items)
                CountItem(countStore, item);
        }

        public string Execute(TInput input)
        {
            Input = input;
            Result = new StringBuilder();

            Analyze();

            return Result.ToString();
        }

        public string Execute(string inputPath)
        {
            var input = new TInput();
            input.Load(inputPath);

            return Execute(input);
        }

        public void ExecuteAndSave(string inputPath, string outputPath)
        {
            Execute(inputPath);
            Save(outputPath);
        }

        public void Save(string outputPath)
        {
            var filePath = Path.Combine(outputPath, Path.ChangeExtension(Input.FileName, ".txt"));
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, Result.ToString());
        }

        protected abstract void Analyze();
    }
}
