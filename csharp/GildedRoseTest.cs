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

        [Test]
        public void AgedBrieIncreasesInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 5; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(10, items[0].Quality);
        }

        [Test]
        public void AfterSellByDate_AgedBrieIncreasesTwiceInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 15; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(25, items[0].Quality);
        }

        [Test]
        public void ConjuredAgedBrieIncreasesTwiceInQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Aged Brie", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 15; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(45, items[0].Quality);
        }

        [Test]
        public void QualityIsPositiveAndLessThan50()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to Electric Castle", SellIn = 21, Quality = 30 },
                new Item { Name = "Elixir of Wrath", SellIn = 10, Quality = 20 }
            };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 20; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(50, items[0].Quality);
            Assert.AreEqual(0, items[1].Quality);
        }

        [Test]
        public void AfterSellByDate_BackstagePassesQualityDropsToZero()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to Electric Castle", SellIn = 10, Quality = 30 },
            };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 11; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void SulfurasHaveFixedQuality()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Mono", SellIn = 200, Quality = 80 },
            };
            GildedRose app = new GildedRose(items);

            for (int i = 1; i <= 300; ++i)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(80, items[0].Quality);
        }
    }
}
