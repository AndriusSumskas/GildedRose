using GildedRose.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Handlers
{
    public class ShopInventoryHandler
    {
        private List<Item> _shopSupplies = null;
        private ItemQualityHandler _itemQualityHandler = null;

        public ShopInventoryHandler()
        {
            _itemQualityHandler = new ItemQualityHandler();
        }
        public ShopInventoryHandler(List<Item> supplies) : this()
        {
            ShopSupplies = supplies;
        }
        public List<Item> ShopSupplies
        {
            get
            {
                if (_shopSupplies == null)
                    _shopSupplies = new List<Item>();
                return _shopSupplies;
            }
            set
            {
                if (_shopSupplies == value)
                    return;
                _shopSupplies = value;
            }
        }        

        public bool UpdateShopSupplies()
        {
            if (ShopSupplies == null || ShopSupplies.Count == 0)
                return false;

            foreach (Item item in ShopSupplies)
                _itemQualityHandler.UpdateItemQuality(item);

            return true;
        }
    }
}
