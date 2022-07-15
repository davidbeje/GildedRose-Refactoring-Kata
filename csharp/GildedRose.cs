using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> items;

        public GildedRose()
        {
            items = new List<Item>();
        }

        public IList<Item> GetItems()
        {
            return items;
        }
        
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(string name)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i].Name == name)
                {
                    items.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAllItems()
        {
            items.Clear();
        }

        public void UpdateItemsQuality()
        {
            foreach (var item in items)
            {
                item.UpdateQuality();
            }
        }
    }
}
