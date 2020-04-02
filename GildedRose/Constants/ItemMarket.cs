using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Constants
{
    public class ItemMarket
    {
        public static int LowestQualityRange = 0;
        public static int HighestQualityRange = 50;

        //Note: Later this method can be changed from static provide real time unique market items from DB or files  
        public static List<string> GetUniqueItemNames()
        {
            return new List<string>() { "Sulfuras", "Backstage passes", "Aged Brie", "Conjured" };
        }
    }
}
