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

        public void bidItem(String type, int quality)
        {
            Item item = itemRepository.FindItems(type, quality);
            if (this.itemRepository.getInventory().Contains(item))
            {
                Console.WriteLine("Cet item coûte : " + item.GetValue());
                
                int i = 0;
                String proposedPrice = "";
                Console.WriteLine("Quel prix proposez vous ?");
                proposedPrice = Console.ReadLine();
                Double upProposedPrice = item.GetValue() * 1.1;
                while(i<2)
                {
                    if(int.Parse(proposedPrice) > upProposedPrice){
                        Console.WriteLine("Proposez un nouveau prix");
                        upProposedPrice = int.Parse(proposedPrice);
                        proposedPrice = Console.ReadLine();
                        
                    }
                    else Console.WriteLine("Erreur, votre prix doit etre 10% suppérieur à l'enchère précédente");
                    i++;
                }
                Console.WriteLine("Adjugé, l'item est vendu pour : $" + proposedPrice);
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