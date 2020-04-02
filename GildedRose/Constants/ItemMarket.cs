using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Constants
{
    public static class ItemMarket
    {
        //Note: Later this method can be changed from static provide real time unique market items from DB or files  
        public static List<string> GetUniqueItemNames()
        {
            return new List<string>() { "Sulfuras", "Backstage passes", "Aged Brie", "Conjured" };
        }
    }
}
