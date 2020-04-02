using GildedRose.Handlers;
using GildedRose.Objects;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            ShopSuppliesHandler suppliesHandler = new ShopSuppliesHandler();

            List<Item> supplies = suppliesHandler.GetSupplies();

            GildedRose app = new GildedRose(supplies);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- Day " + i + " --------");
                Console.WriteLine("Name, SellIn, Quality");
                foreach (Item item in supplies)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
            Console.ReadLine();
        }

    }
}
