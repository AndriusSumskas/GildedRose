using GildedRose.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Handlers
{
    public class SupplieChainHandler
    {
        public SupplieChainHandler()
        {
        }

        /// <summary>
        /// Method used to retrieve all the supplies from different markets.
        /// Note: This method can be later used to merge different ways of receiving supplies (Files, DB, Hardcoded)
        /// </summary>
        public List<Item> GetSupplies()
        {
            List<Item> supplies = new List<Item>();
            supplies.AddRange(GetLocalMarketSupplies());
            return supplies;
        }

        private List<Item> GetLocalMarketSupplies()
        {
            List<Item> result = new List<Item>();
            result.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
            result.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });
            result.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 });
            result.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
            result.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 });
            result.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 });
            result.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 });
            result.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 });
            result.Add(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });

            return result;
        }
    }
}
