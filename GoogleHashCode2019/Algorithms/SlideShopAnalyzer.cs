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
        public Dictionary<String, int> TagCount = new Dictionary<string, int>();

        protected override void Analyze()
        {
            HorizontalCount = Input.Photos.Count(q => q.Orientation == Orientation.Horizontal);
            VertivalCount = Input.Photos.Count(q => q.Orientation == Orientation.Vertical);

            Dump($"PhotoCount Horizontal {HorizontalCount}, Vertical {VertivalCount}, Total {Input.Photos.Count}");

            CountItems(TagCount, Input.Photos.SelectMany(q => q.Tags));

            Dump($"Tag Count {TagCount.Count}");

            Dump("Counts per Tag", TagCount);
        }
    }
}
