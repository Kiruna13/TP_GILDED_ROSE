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
        }

        [TestMethod]
        public void Should_UpdateItemProperties()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(9, this.items.getInventory()[0].sellIn);
            Assert.AreEqual(8, this.items.getInventory()[0].quality);
        }

        [TestMethod]
        public void Should_DecreaseQualityTwiceAsFastAfterExpiration()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(6, this.items.getInventory()[1].quality);
        }

        [TestMethod]
        public void Should_NotHaveNegativeQuality()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(0, this.items.getInventory()[2].quality);
        }

        [TestMethod]
        public void Should_IncreaseAgedBrieQuality()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(5, this.items.getInventory()[3].quality);
        }

        [TestMethod]
        public void Should_NotIncreaseQualityPastFifty()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(50, this.items.getInventory()[4].quality);
        }

        [TestMethod]
        public void Should_NotUpdateLegendaryItemProperties()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(5, this.items.getInventory()[5].sellIn);
            Assert.AreEqual(80, this.items.getInventory()[5].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQuality()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(11, this.items.getInventory()[6].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoTenDaysBefore()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(12, this.items.getInventory()[7].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityByTwoFiveDaysBefore()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(13, this.items.getInventory()[8].quality);
        }

        [TestMethod]
        public void Should_IncreaseBackstagePassQualityToZeroAfterEvent()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(0, this.items.getInventory()[9].quality);
        }

        [TestMethod]
        public void Should_DecreaseConjuredItemQualityBy2()
        {
            this.shop.UpdateInventory();
            Assert.AreEqual(8, this.items.getInventory()[10].quality);
        }

        [TestMethod]
        public void Should_SellItem()
        {
            this.shop.SellItem("Conjured", 10);
            Assert.AreEqual(10, this.items.getInventory().Count);
            Assert.AreEqual(127, this.shop.Balance);
        }
    }
}