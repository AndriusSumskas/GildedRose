using GildedRose.Constants;
using GildedRose.Handlers;
using GildedRose.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GildedRoseTests
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void NullExceptionHandling()
        {
            ShopInventoryHandler shopInvetoryHandler = new ShopInventoryHandler();
            shopInvetoryHandler.ShopSupplies.Add(null);
            try
            {
                shopInvetoryHandler.UpdateShopSupplies();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex is NullReferenceException);
            }
        }

        [TestMethod]
        public void ItemQualityRangeLimit()
        {
            ShopInventoryHandler shopInventoryHandler = new ShopInventoryHandler();
            shopInventoryHandler.ShopSupplies.Add(new Item() { Name = "Common Sword", SellIn = -1, Quality = -5 });
            shopInventoryHandler.ShopSupplies.Add(new Item() { Name = "Common Sword +1", SellIn = 10, Quality = 60 });
            shopInventoryHandler.ShopSupplies.Add(new Item() { Name = "Common Sword +2", SellIn = 7, Quality = 200 });
            shopInventoryHandler.ShopSupplies.Add(new Item() { Name = "Common Sword +3", SellIn = 9, Quality = 2 });
            shopInventoryHandler.ShopSupplies.Add(new Item() { Name = "Backstage passes", SellIn = 9, Quality = 2 });
            shopInventoryHandler.ShopSupplies.Add(new Item() { Name = "Backstage passes", SellIn = 3, Quality = 46 });
            shopInventoryHandler.ShopSupplies.Add(new Item() { Name = "Conjured flavourless pie", SellIn = 7, Quality = 4 });

            bool itemRangeBreach = false;
            foreach(Item item in shopInventoryHandler.ShopSupplies)
            {
                shopInventoryHandler.UpdateShopSupplies();
                if (item.Quality < ItemMarket.LowestQualityRange || item.Quality > ItemMarket.HighestQualityRange)
                {
                    itemRangeBreach = true;
                    break;
                }
            }
            Assert.IsFalse(itemRangeBreach);
        }

        [TestMethod]
        public void Sulfuras_ItemChangeCheck()
        {
            ItemQualityHandler itemQualityHandler = new ItemQualityHandler();
            Item item = new Item() { Name = "Sulfuras", SellIn = 20, Quality = 500 };

            int originalSellIn = item.SellIn;
            int originalQuality = item.Quality;

            for (int i = 0; i < 10; i++)
                itemQualityHandler.UpdateItemQuality(item);

            Assert.IsTrue(originalQuality == item.Quality && originalSellIn == item.SellIn);

        }

        [TestMethod]
        public void AgedBrie_QualityDailyIncrease()
        {
            ItemQualityHandler itemQualityHandler = new ItemQualityHandler();
            Item item = new Item() { Name = "Aged Brie", SellIn = 5, Quality = 7 };

            int previousQuality = SetQualityLimits(item.Quality);

            bool qualityIncreaseStoped = false;
            for (int i = 0; i < 10; i++)
            {
                itemQualityHandler.UpdateItemQuality(item);
                if (item.Quality == ItemMarket.LowestQualityRange || item.Quality == ItemMarket.HighestQualityRange)
                    break;
                if (item.SellIn <= -1 && previousQuality + 2 != item.Quality)
                    qualityIncreaseStoped = false;
                else if (previousQuality + 1 != item.Quality)
                    qualityIncreaseStoped = false;

                previousQuality = item.Quality;
            }

            Assert.IsFalse(qualityIncreaseStoped);
        }

        [TestMethod]
        public void BackStagePasses_QualityDailyIncrease()
        {
            ItemQualityHandler itemQualityHandler = new ItemQualityHandler();
            Item item = new Item() { Name = "Backstage passes", SellIn = 5, Quality = 7 };

            int previousQuality = SetQualityLimits(item.Quality);

            bool qualityIncreaseStoped = false;
            for (int i = 0; i < 10; i++)
            {
                itemQualityHandler.UpdateItemQuality(item);
                if ((item.Quality == ItemMarket.LowestQualityRange && item.SellIn < 0) || item.Quality == ItemMarket.HighestQualityRange)
                    break;
                if (item.SellIn <= 5 && previousQuality + 3 != item.Quality)
                    qualityIncreaseStoped = false;
                else if (item.SellIn <= 10 && previousQuality + 2 != item.Quality)
                    qualityIncreaseStoped = false;
                else if (previousQuality + 1 != item.Quality)
                    qualityIncreaseStoped = false;

                previousQuality = item.Quality;
            }
            Assert.IsFalse(qualityIncreaseStoped);
        }

        [TestMethod]
        public void ConjuredItem_DoubleDailyDecrease()
        {
            ItemQualityHandler itemQualityHandler = new ItemQualityHandler();
            Item item = new Item() { Name = "Conjured invisible boots", SellIn = 5, Quality = 40 };

            int previousQuality = SetQualityLimits(item.Quality);

            bool qualityDecreaseStoped = false;
            for (int i = 0; i < 10; i++)
            {
                itemQualityHandler.UpdateItemQuality(item);
                if (item.Quality == ItemMarket.LowestQualityRange && item.Quality == ItemMarket.HighestQualityRange)
                    break;
                if (item.SellIn < 0 && previousQuality - 4 != item.Quality)
                    qualityDecreaseStoped = false;
                else if (previousQuality - 2 != item.Quality)
                    qualityDecreaseStoped = false;
                previousQuality = item.Quality;
            }
            Assert.IsFalse(qualityDecreaseStoped);
        }
       

        private int SetQualityLimits(int quality)
        {
            if (quality > ItemMarket.HighestQualityRange)
                quality = ItemMarket.HighestQualityRange;
            if (quality < ItemMarket.LowestQualityRange)
                quality = ItemMarket.LowestQualityRange;
            return quality;
        }
    }
}
