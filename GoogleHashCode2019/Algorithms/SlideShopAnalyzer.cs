using GoogleHashCode2019.Base;
using GoogleHashCode2019.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GoogleHashCode2019.Algorithms
{
    public class SlideShopAnalyzer : Analyzer<SlideShowInput>
    {
        public int HorizontalCount;
        public int VertivalCount;
        public CountStore<String> TagCount = new CountStore<string>();
        public CountStore<int> TagListLength = new CountStore<int>();
        public CountStore<String> TagUnique = new CountStore<string>();

        protected override void Analyze()
        {
            HorizontalCount = Input.Photos.Count(q => q.Orientation == Orientation.Horizontal);
            VertivalCount = Input.Photos.Count(q => q.Orientation == Orientation.Vertical);

            Dump($"PhotoCount Horizontal {HorizontalCount}, Vertical {VertivalCount}, Total {Input.Photos.Count}");

            TagCount.Add(Input.Photos.SelectMany(q => q.Tags));

            Dump("Tags", TagCount);

            TagListLength.Add(Input.Photos.Select(q => q.Tags.Count));

            Dump("Length of TagList", TagListLength);
        }
    }
}
