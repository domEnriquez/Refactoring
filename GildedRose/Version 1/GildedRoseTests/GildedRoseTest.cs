using GildedRoseApp;
using ItemDomain;
using ItemImplementation;
using NUnit.Framework;
using System.Collections.Generic;
using static ItemDomain.EditableItem;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTest
    {
        private const int MAX_QUANTITY = 50;
        IList<EditableItem> items;

        [SetUp]
        public void SetUp()
        {
            items = new List<EditableItem>();
        }

        [TearDown]
        public void TearDown()
        {
            items.Clear();
        }

        [Test]
        public void decrementNormalItemQualityOnceAfterADay()
        {
            items.Add(new EditableItem { Name = "Berger", SellIn = 2, Quality = 5 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(4, items[0].Quality);
            Assert.AreEqual(1, items[0].SellIn);
        }
        
        [Test]
        public void itemQualityNeverNegative()
        {
            items.Add(new EditableItem { Name = "Syomay", SellIn = 5, Quality = 0 });
            items.Add(new ConcertBackstagePass { Name = "TaylorFast", SellIn = 0, Quality = 0 });
            items.Add(new Conjured { Name = "Conjured", SellIn = 0, Quality = 2 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(0, items[1].Quality);
            Assert.AreEqual(0, items[2].Quality);
        }

        [Test]
        public void throwErrorWhenItemQualityIsInitiallyGreaterThan50()
        {
            items.Add(new EditableItem { Name = "Item", SellIn = 5, Quality = 51 });
            Assert.Throws<QualityExceededLimitException>(() => new GildedRose(items));
        }

        [Test]
        public void itemQualityNeverExceedsMaxWhenIncrementingPerDay()
        {
            items.Add(new AgedBrie{ Name = "Aged Brie", SellIn = 3, Quality = MAX_QUANTITY });
            items.Add(new ConcertBackstagePass { Name = "TaylorFast", SellIn = 3, Quality = MAX_QUANTITY });
            GildedRose app = new GildedRose(items);
            Assert.AreEqual(MAX_QUANTITY, items[0].Quality);
            Assert.AreEqual(MAX_QUANTITY, items[1].Quality);
        }

        [Test]
        public void incrementAgedBrieQualityOnceAfterADayWhenNotYetExceededSellInDays()
        {
            items.Add(new AgedBrie { Name = "Aged Brie", SellIn = 2, Quality = 0 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(1, items[0].Quality);
            Assert.AreEqual(1, items[0].SellIn);
        }

        [Test]
        public void incrementAgedBrieQualityTwiceAfterADayWhenExceededSellInDays()
        {
            items.Add(new AgedBrie { Name = "Aged Brie", SellIn = -1, Quality = 10 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(12, items[0].Quality);
            Assert.AreEqual(-2, items[0].SellIn);
        }

        [Test]
        public void zeroOutConcertPassQualityAfterADayWhenExceededSellInDays()
        {
            items.Add(new ConcertBackstagePass { Name = "Backstage Pass", SellIn = -1, Quality = 0 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(-2, items[0].SellIn);
        }

        [Test]
        public void incrementConcertPassQualityOnceAfterADayWhenSellInDaysMoreThan10()
        {
            items.Add(new ConcertBackstagePass { Name = "Backstage Pass", SellIn = 11, Quality = 20 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(21, items[0].Quality);
            Assert.AreEqual(10, items[0].SellIn);
        }

        [Test]
        public void incrementConcertPassQualityTwiceAfterADayWhenSellInDaysLessThan10()
        {
            items.Add(new ConcertBackstagePass { Name = "Backstage Pass", SellIn = 10, Quality = 20 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(22, items[0].Quality);
            Assert.AreEqual(9, items[0].SellIn);
        }

        [Test]
        public void incrementConcertPassQualityThriceAfterADayWhenSellInDaysLessThan10()
        {
            items.Add(new ConcertBackstagePass { Name = "Backstage Pass", SellIn = 5, Quality = 20 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(23, items[0].Quality);
            Assert.AreEqual(4, items[0].SellIn);
        }

        [Test]
        public void sulfurasQualityDoesNotDecreaseAfterADay()
        {
            items.Add(new Sulfuras { Name = "Sulfuras", SellIn = 5, Quality = 20 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(20, items[0].Quality);
        }

        [Test]
        public void sulfurasSellInDoesNotDecreaseAfterADay()
        {
            items.Add(new Sulfuras { Name = "Sulfuras", SellIn = 5, Quality = 20 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(5, items[0].SellIn);
        }

        [Test]
        public void decreaseConjuredQualityTwiceAfterADay()
        {
            items.Add(new Conjured { Name = "Conjured", SellIn = 5, Quality = 20 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(18, items[0].Quality);
        }

        [Test]
        public void decreaseConjuredQualityFourTimesAfterADayWhenExceededSellInDays()
        {
            items.Add(new Conjured { Name = "Conjured", SellIn = 0, Quality = 20 });
            GildedRose app = new GildedRose(items);
            app.UpdateItemsQualityAfterADay();
            Assert.AreEqual(-1, items[0].SellIn);
            Assert.AreEqual(16, items[0].Quality);
        }


    }
}
