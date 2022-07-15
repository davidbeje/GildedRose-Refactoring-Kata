using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    class BackstagePass : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else if (SellIn <= 5)
            {
                Quality = Math.Min(50, Quality + 3);
            }
            else if (SellIn <= 10)
            {
                Quality = Math.Min(50, Quality + 2);
            }
            else
            {
                Quality = Math.Min(50, Quality + 1);
            }
        }
    }
}
