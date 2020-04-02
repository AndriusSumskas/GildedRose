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

            SupplieChainHandler suppliesHandler = new SupplieChainHandler(); 
            ShopInventoryHandler shopInventoryHandler = new ShopInventoryHandler(suppliesHandler.GetSupplies());
            
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- Day " + i + " --------");
                Console.WriteLine("Name, SellIn, Quality");
                foreach (Item item in shopInventoryHandler.ShopSupplies)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");
                //Note: Later Status can be updated to return problems in update iterations
                bool inventoryUpdateStatus = shopInventoryHandler.UpdateShopSupplies();
                if (!inventoryUpdateStatus)
                {
                    Console.WriteLine("--------- Shop is out of supplies --------");
                    break;
                }
            }
            Console.ReadLine();
        }

    }
}
