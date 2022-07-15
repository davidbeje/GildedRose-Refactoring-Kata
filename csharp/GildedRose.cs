using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (!items[i].Name.Contains("Sulfuras"))
                {
                    int qualityChange;
                    
                    if (items[i].Name.Contains("Backstage passes"))
                    {
                        if (items[i].SellIn <= 0)
                        {
                            qualityChange = -items[i].Quality;
                        } 
                        else if (items[i].SellIn <= 5)
                        {
                            qualityChange = 3;
                        }
                        else if (items[i].SellIn <= 10)
                        {
                            qualityChange = 2;
                        }
                        else
                        {
                            qualityChange = 1;
                        }
                    }
                    else
                    {
                        int changeRate = 1;

                        if (items[i].SellIn <= 0)
                        {
                            changeRate *= 2;
                        }

                        if (items[i].Name.Contains("Conjured"))
                        {
                            changeRate *= 2;
                        }

                        if (items[i].Name.Contains("Aged Brie"))
                        {
                            qualityChange = changeRate;
                        }
                        else
                        {
                            qualityChange = -changeRate;
                        }
                    }

                    items[i].Quality = Math.Max(0, Math.Min(50, items[i].Quality + qualityChange));
                }

                items[i].SellIn--;
            }
        }
    }
}
