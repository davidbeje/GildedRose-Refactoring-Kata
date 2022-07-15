using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    class AgedBrie : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 0)
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
