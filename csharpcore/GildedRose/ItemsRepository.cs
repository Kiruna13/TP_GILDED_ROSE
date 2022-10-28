using System.Collections.Generic;

namespace GildedRoseKata
{
    public interface ItemsRepository
    {
        public IList<Item> getInventory();


        public void saveInventory(IList<Item> items);

    }
}

