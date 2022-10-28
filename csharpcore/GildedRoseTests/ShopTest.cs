using GildedRoseKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestClass]
    public class ShopTest
    {
        public Shop shop;

        public ItemsRepository items;
        
        [TestInitialize]
        public void Setup()
        {
            this.items = new InMermoryItemsRepository();
            this.shop = new Shop(this.items);
            this.shop.UpdateQuality();
        }
        
        [TestMethod]
        public void Should_UpdateItemProperties()
        {
            Assert.AreEqual(9, this.items.getInventory()[0].sellIn);
            Assert.AreEqual(8, this.items.getInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration()
        {
            Assert.AreEqual(6, this.items.getInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality()
        {
            Assert.AreEqual(0, this.items.getInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality()
        {
            Assert.AreEqual(5, this.items.getInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityPastFifty()
        {
            Assert.AreEqual(50, this.items.getInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties()
        {
            Assert.AreEqual(5, this.items.getInventory()[5].sellIn);
            Assert.AreEqual(80, this.items.getInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality()
        {
            Assert.AreEqual(11, this.items.getInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore()
        {
            Assert.AreEqual(12, this.items.getInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoFiveDaysBefore()
        {
            Assert.AreEqual(13, this.items.getInventory()[8].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityToZeroAfterEvent()
        {
            Assert.AreEqual(0, this.items.getInventory()[9].quality);
        }
        
        [TestMethod]
        public void Should_DecreaseConjuredItemQualityBy2()
        {
            Assert.AreEqual(8, this.items.getInventory()[10].quality);
        }
        
    }
    
}