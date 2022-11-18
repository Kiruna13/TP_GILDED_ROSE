using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public interface ItemsRepository
    {
        public IList<Item> getInventory();


        public void saveInventory(IList<Item> items);

        public Item FindItems(string type, int quality);
    }
}

