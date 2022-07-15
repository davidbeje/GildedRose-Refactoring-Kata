using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    class BasicItem : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 0)
            {
                Quality = Math.Max(0, Quality - 2);
            }
            else
            {
                Quality = Math.Max(0, Quality - 1);
            }
        }
    }
}
