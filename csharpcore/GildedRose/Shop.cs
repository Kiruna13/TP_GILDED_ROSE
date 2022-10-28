using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Shop
    {
        private ItemsRepository itemRepository;

        public Shop(ItemsRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void UpdateQuality()
        {
            IList<Item> items = this.itemRepository.getInventory();
            foreach(Item item in items)
            {
                item.Update();
            }
            this.itemRepository.saveInventory(items);
        }
    }
}