using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void AfterSellByDate_QualityDegradesTwiceAsFast()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Big Mac", SellIn = 5, Quality = 50 } };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 10; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(35, items[0].Quality);
        }

        [Test]
        public void ConjuredItemsDegradeTwiceAsFast()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Apple Pie", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 5; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
