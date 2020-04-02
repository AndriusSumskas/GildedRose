using GildedRose.Constants;
using GildedRose.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Handlers
{
    public class ItemQualityHandler
    {
        public ItemQualityHandler()
        {
        }

        public void UpdateItemQuality(Item item)
        {
            if (item == null)
                return;
            if (IsUniqueItem(item))
            {
                UpdateUniqueItem(item);
                return;
            }
            UpdateCommonItem(item);
        }

        private bool IsUniqueItem(Item item)
        {
            foreach(string name in ItemMarket.GetUniqueItemNames())
            {
                if (item.Name.Contains(name))
                    return true;
            }
            return false;
        }
        private void UpdateUniqueItem(Item item)
        {
            if (item.Name.Contains("Sulfuras"))
                return;

            int qualityMultiplier = item.SellIn <= 0 ? 2 : 1;
            if(item.Name.Contains("Conjured"))
                qualityMultiplier *= 2;

            if (item.Name.Contains("Backstage passes"))
            {
                if (item.SellIn <= 0)
                    item.Quality = 0;
                else if (item.SellIn < 6)
                    item.Quality += 3;
                else if (item.SellIn < 11)
                    item.Quality += 2;
                else
                    item.Quality += 1;
            }
            else if(item.Name.Contains("Aged Brie"))
            {
                item.Quality += (1 * qualityMultiplier);
            }
            else
            {
                item.Quality -= (1 * qualityMultiplier);
            }


            item.SellIn -= 1;
            CheckItemLimits(item);
        }
        private void UpdateCommonItem(Item item)
        {
            item.Quality -= item.SellIn <= 0 ? 2 : 1;
            item.SellIn -= 1;
            CheckItemLimits(item);
        }
        private void CheckItemLimits(Item item)
        {
            if (item.Quality > 50)
                item.Quality = 50;
            if (item.Quality < 0)
                item.Quality = 0;
        }
    }
}
