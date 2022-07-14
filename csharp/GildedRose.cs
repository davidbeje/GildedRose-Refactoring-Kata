using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (!Items[i].Name.Contains("Sulfuras"))
                {
                    if (Items[i].Name.Contains("Backstage passes"))
                    {
                        if (Items[i].SellIn <= 0)
                        {
                            Items[i].Quality = 0;
                        } 
                        else if (Items[i].SellIn <= 5)
                        {
                            Items[i].Quality += 3;
                        }
                        else if (Items[i].SellIn <= 10)
                        {
                            Items[i].Quality += 2;
                        }
                        else
                        {
                            Items[i].Quality++;
                        }
                    }
                    else
                    {
                        int changeRate = 1;
                        int qualityChange;

                        if (Items[i].SellIn <= 0)
                        {
                            changeRate *= 2;
                        }

                        if (Items[i].Name.Contains("Conjured"))
                        {
                            changeRate *= 2;
                        }

                        if (Items[i].Name == "Aged Brie")
                        {
                            qualityChange = changeRate;
                        }
                        else
                        {
                            qualityChange = -changeRate;
                        }

                        Items[i].Quality = Math.Max(0, Math.Min(50, Items[i].Quality + qualityChange));
                    }
                }

                Items[i].SellIn--;
            }
        }
    }
}
