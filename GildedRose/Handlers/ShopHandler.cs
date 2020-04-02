using GildedRose.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Handlers
{
    public class ShopHandler
    {
        public static void OpenShopForBusiness(int countOfDays)
        {
            SupplieChainHandler suppliesHandler = new SupplieChainHandler();
            ShopInventoryHandler shopInventoryHandler = new ShopInventoryHandler(suppliesHandler.GetSupplies());

            for (var i = 0; i < countOfDays; i++)
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
