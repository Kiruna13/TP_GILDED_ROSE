using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GildedRoseKata
{
    public class Shop
    {
        private ItemsRepository itemRepository;
        private int balance;
        public int Balance => this.balance;
        public Shop(ItemsRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void UpdateInventory()
        {
            IList<Item> items = this.itemRepository.getInventory();
            foreach(Item item in items)
            {
                item.Update();
            }
            this.itemRepository.saveInventory(items);
        }

        public void SellItem(String type, int quality)
        {
            Item item = itemRepository.FindItems(type, quality);
            if (this.itemRepository.getInventory().Contains(item))
            {
                itemRepository.getInventory().Remove(item);
                this.balance += item.GetValue();
                this.itemRepository.saveInventory(this.itemRepository.getInventory());
            }
            else
            {
                Console.WriteLine("Article non disponible en magasin");
            }
        }
    }
}