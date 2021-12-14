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
        CompositeItem items;

        [SetUp]
        public void SetUp()
        {
            items = new CompositeItem();
        }

        [TearDown]
        public void TearDown()
        {
            items.Clear();
        }

        [Test]
        public void decrementNormalItemQualityOnceAfterADay()
        {
            EditableItem item = EditableItem.Create("Berger", sellIn: 2, quality: 5);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(1, item.SellIn);
        }
        
        [Test]
        public void itemQualityNeverNegative()
        {
            EditableItem item1 = EditableItem.Create("Syomay", sellIn: 5, quality: 0);
            EditableItem backstagePass = ConcertBackstagePass.Create("TaylorFast", sellIn: 0, quality: 0);
            EditableItem conjured = Conjured.Create("Conjured", sellIn: 0, quality: 2);
            items.Add(item1);
            items.Add(backstagePass);
            items.Add(conjured);

            GildedRose app = new GildedRose(items);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(0, item1.Quality);
            Assert.AreEqual(0, backstagePass.Quality);
            Assert.AreEqual(0, conjured.Quality);
        }

        [Test]
        public void throwErrorWhenItemQualityIsInitiallyGreaterThan50()
        {
            EditableItem item = EditableItem.Create("Item", sellIn: 5, quality: MAX_QUANTITY + 1);

            Assert.Throws<QualityExceededLimitException>(() => new GildedRose(item));
        }

        [Test]
        public void itemQualityNeverExceedsMaxWhenIncrementingPerDay()
        {
            EditableItem agedBrie = AgedBrie.Create(sellIn: 3, quality: MAX_QUANTITY);
            EditableItem backstagePass = 
                ConcertBackstagePass.Create(concertName: "TaylorFast", sellIn: 3, quality: MAX_QUANTITY);
            items.Add(agedBrie);
            items.Add(backstagePass);

            GildedRose app = new GildedRose(items);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(MAX_QUANTITY, agedBrie.Quality);
            Assert.AreEqual(MAX_QUANTITY, backstagePass.Quality);
        }

        [Test]
        public void incrementAgedBrieQualityOnceAfterADayWhenNotYetExceededSellInDays()
        {
            AgedBrie item = AgedBrie.Create(sellIn: 2, quality: 0);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(1, item.Quality);
            Assert.AreEqual(1, item.SellIn);
        }

        [Test]
        public void incrementAgedBrieQualityTwiceAfterADayWhenExceededSellInDays()
        {
            AgedBrie item = AgedBrie.Create(sellIn: -1, quality: 10);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(12, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }

        [Test]
        public void zeroOutConcertPassQualityAfterADayWhenExceededSellInDays()
        {
            ConcertBackstagePass item = 
                ConcertBackstagePass.Create(concertName: "Backstage Pass", sellIn: -1, quality: 0);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }

        [Test]
        public void incrementConcertPassQualityOnceAfterADayWhenSellInDaysMoreThan10()
        {
            ConcertBackstagePass item = 
                ConcertBackstagePass.Create(concertName: "Backstage Pass", sellIn: 11, quality: 20);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(21, item.Quality);
            Assert.AreEqual(10, item.SellIn);
        }

        [Test]
        public void incrementConcertPassQualityTwiceAfterADayWhenSellInDaysLessThan10()
        {
            ConcertBackstagePass item = 
                ConcertBackstagePass.Create(concertName: "Backstage Pass", sellIn: 10, quality: 20);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(22, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void incrementConcertPassQualityThriceAfterADayWhenSellInDaysLessThan10()
        {
            ConcertBackstagePass item = 
                ConcertBackstagePass.Create(concertName: "Backstage Pass", sellIn: 5, quality: 20);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(23, item.Quality);
            Assert.AreEqual(4, item.SellIn);
        }

        [Test]
        public void sulfurasQualityDoesNotDecreaseAfterADay()
        {
            Sulfuras item = Sulfuras.Create(sellIn: 5, quality: 20);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(20, item.Quality);
        }

        [Test]
        public void sulfurasSellInDoesNotDecreaseAfterADay()
        {
            Sulfuras item = Sulfuras.Create(sellIn: 5, quality: 20);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(5, item.SellIn);
        }

        [Test]
        public void decreaseConjuredQualityTwiceAfterADay()
        {
            Conjured item = Conjured.Create(name: "Conjured", sellIn: 5, quality: 20);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(4, item.SellIn);
            Assert.AreEqual(18, item.Quality);
        }

        [Test]
        public void decreaseConjuredQualityFourTimesAfterADayWhenExceededSellInDays()
        {

            Conjured item = Conjured.Create(name: "Conjured", sellIn: 0, quality: 20);
            GildedRose app = new GildedRose(item);

            app.UpdateItemsQualityAfterADay();

            Assert.AreEqual(-1, item.SellIn);
            Assert.AreEqual(16, item.Quality);
        }


    }
}
