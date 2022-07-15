using NUnit.Framework;
using System.Collections.Generic;
using System.Dynamic;
using csharp.Items;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private GildedRose app;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            app = new GildedRose();
        }

        [TearDown]
        public void TearDown()
        {
            app.RemoveAllItems();
        }

        [Test]
        public void foo()
        {
            // given
            app.AddItem(new BasicItem { Name = "foo", SellIn = 0, Quality = 0 });

            // when
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual("foo", app.GetItems()[0].Name);
        }

        [Test]
        public void QualityDegradesTwiceAsFast_AfterSellByDate()
        {
            // given
            app.AddItem(new BasicItem { Name = "Big Mac", SellIn = 0, Quality = 20 });

            // when
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(18, app.GetItems()[0].Quality);
        }

        [Test]
        public void ConjuredItemsDegradeTwiceAsFast()
        {
            // given
            app.AddItem(new ConjuredItem { Name = "Conjured Apple Pie", SellIn = 5, Quality = 10 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(8, app.GetItems()[0].Quality);
        }

        [Test]
        public void AgedBrieIncreasesInQuality()
        {
            // given
            app.AddItem(new AgedBrie { Name = "Aged Brie", SellIn = 10, Quality = 5 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(6, app.GetItems()[0].Quality);
        }

        [Test]
        public void AgedBrieIncreasesTwiceInQuality_AfterSellByDate()
        {
            // given
            app.AddItem(new AgedBrie { Name = "Aged Brie", SellIn = 0, Quality = 5 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(7, app.GetItems()[0].Quality);
        }

        [Test]
        public void QualityIsNeverNegative()
        {
            // given
            app.AddItem(new BasicItem { Name = "Elixir of Wrath", SellIn = 10, Quality = 0 });
            
            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(0, app.GetItems()[0].Quality);
        }

        [Test]
        public void QualityIsAlwaysLessThan50()
        {
            // given
            app.AddItem(new BackstagePass { Name = "Backstage passes to Electric Castle", SellIn = 4, Quality = 48 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(50, app.GetItems()[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesBy1_WhenThereAreMoreThan10DaysLeft()
        {
            // given
            app.AddItem(new BackstagePass { Name = "Backstage passes to Electric Castle", SellIn = 20, Quality = 12 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(13, app.GetItems()[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesBy2_WhenThereAre10DaysOrLessLeft()
        {
            // given
            app.AddItem(new BackstagePass { Name = "Backstage passes to Electric Castle", SellIn = 7, Quality = 21 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(23, app.GetItems()[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityIncreasesBy3_WhenThereAre5DaysOrLessLeft()
        {
            // given
            app.AddItem(new BackstagePass { Name = "Backstage passes to Electric Castle", SellIn = 4, Quality = 39 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(42, app.GetItems()[0].Quality);
        }

        [Test]
        public void BackstagePassesQualityDropsToZero_AfterSellByDate()
        {
            // given
            app.AddItem(new BackstagePass { Name = "Backstage passes to Electric Castle", SellIn = 0, Quality = 30 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(0, app.GetItems()[0].Quality);
        }

        [Test]
        public void SulfurasHaveFixedQuality()
        {
            // given
            app.AddItem(new Sulfuras { Name = "Sulfuras, Hand of Mono", SellIn = 200, Quality = 80 });

            // where
            app.UpdateItemsQuality();

            // then
            Assert.AreEqual(80, app.GetItems()[0].Quality);
        }
    }
}
