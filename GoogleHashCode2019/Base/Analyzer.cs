using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace GoogleHashCode2019.Base
{
    public abstract class Analyzer<TInput> where TInput : Input, new()
    {
        public class CountStore<T> : IEnumerable<KeyValuePair<T, int>>
        {
            private readonly Dictionary<T, int> Data = new Dictionary<T, int>();
            public int Min { get => Data.Values.Min(); }
            public int Max { get => Data.Values.Max(); }
            public int Count { get => Data.Count; }
            public double Avgerage { get => Data.Values.Average(); }

            public void Add(T item)
            {
                if (!Data.TryGetValue(item, out var count))
                    count = 0;
                count++;
                Data[item] = count;
            }

            public void Add(IEnumerable<T> items)
            {
                foreach (var item in items)
                    Add(item);
            }

            public IEnumerator<KeyValuePair<T, int>> GetEnumerator()
            {
                return Data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Data.GetEnumerator();
            }

            public int this[T Item]
            {
                get { return Data[Item]; }
            }
        }

        public class DictionaryHashSetValue<TKey, TValue> : IEnumerable<KeyValuePair<TKey, HashSet<TValue>>>
        {
            private readonly Dictionary<TKey, HashSet<TValue>> Data = new Dictionary<TKey, HashSet<TValue>>();

            public int Count => Data.Count;

            public void Add(TKey key, TValue value)
            {
                if (!Data.TryGetValue(key, out var hashSet))
                {
                    hashSet = new HashSet<TValue>();
                    Data.Add(key, hashSet);
                }
                hashSet.Add(value);
            }

            public void Add(TKey key, IEnumerable<TValue> values)
            {
                if (!Data.TryGetValue(key, out var hashSet))
                {
                    hashSet = new HashSet<TValue>();
                    Data.Add(key, hashSet);
                }
                foreach (var item in values)
                    hashSet.Add(item);
            }

            public void Add(IEnumerable<KeyValuePair<TKey, TValue>> keyValueItems)
            {
                foreach (var item in keyValueItems)
                    Add(item.Key, item.Value);
            }

            public KeyValuePair<TKey, TValue> Pair(TKey key, TValue value)
            {
                return new KeyValuePair<TKey, TValue>(key, value);
            }

            public IEnumerator<KeyValuePair<TKey, HashSet<TValue>>> GetEnumerator()
            {
                return Data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Data.GetEnumerator();
            }

            public HashSet<TValue> this[TKey Item]
            {
                get { return Data[Item]; }
            }
        }

        protected StringBuilder Result;
        protected StringBuilder ResultDetail;
        protected TInput Input;

        protected void Dump(string msg, bool lineSeparator = true)
        {
            if (!String.IsNullOrEmpty(msg))
            {
                Result.AppendLine(msg);
                if (lineSeparator)
                    Result.AppendLine();
            }
        }

        protected void Dump<K>(string msg, CountStore<K> data)
        {
            Dump(msg, false);
            Result.
                AppendLine($"- Number of Items: {data.Count}").
                AppendLine($"- Min Count: {data.Min}").
                AppendLine($"- Max Count: {data.Max}").
                AppendLine($"- Average Count: {data.Avgerage}");

            var dataSorted = data.OrderByDescending(q => q.Value).ToList();
            if (dataSorted.Count > 20)
            {
                Dump("Top 20 Elements", dataSorted.Take(20), false);
                Dump(msg, dataSorted, true);
            }
            else
                Dump("", dataSorted, false);
        }

        protected void Dump<K, V>(string msg, DictionaryHashSetValue<K, V> data)
        {
            Dump(msg, false);
            Result.
                AppendLine($"- Number of Items: {data.Count}");

            Func<HashSet<V>, String> valueToString = (q) => string.Join(", ", q);

            var dataSorted = data.OrderByDescending(q => q.Value.Count).ToList();
            if (dataSorted.Count > 20)
            {
                Dump("Top 20 Elements", dataSorted.Take(20), false, valueToString);
                Dump(msg, dataSorted, true, valueToString);
            }
            else
                Dump("", dataSorted, false, valueToString);
        }

        protected void Dump<K, V>(string msg, IEnumerable<KeyValuePair<K, V>> data, bool toDetail = false, Func<V, string> fnValueToString = null)
        {
            var index = 0;
            var result = toDetail ? ResultDetail : Result;

            if (fnValueToString == null)
                fnValueToString = (q) => q.ToString();

            if (!string.IsNullOrEmpty(msg))
                result.AppendLine(msg);

            foreach (var item in data)
                result.AppendLine($"{++index}) {item.Key} = {fnValueToString(item.Value)}");

            result.AppendLine();
        }

        public string Execute(TInput input)
        {
            Input = input;
            Result = new StringBuilder();
            ResultDetail = new StringBuilder();

            Analyze();

            if (Result.Length > 0 && ResultDetail.Length > 0)
            {
                Result.AppendLine().AppendLine("Detailed Data").AppendLine().Append(ResultDetail.ToString());
                ResultDetail.Length = 0;
            }
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
