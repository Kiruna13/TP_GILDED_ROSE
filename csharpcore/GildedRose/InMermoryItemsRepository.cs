using System.Collections.Generic;

namespace GildedRoseKata
{
    public class InMermoryItemsRepository : ItemsRepository
    {
        private IList<Item> items = new List<Item>(){
            new GenericItem("Wang", 10, 9),
            new GenericItem("Sword", -1, 8),
            new GenericItem("Shield", -1, 0),
            new AgingItem("Aged Brie", 5, 4),
            new AgingItem("Aged Brie", 5, 50),
            new LegendaryItem("Sulfuras", 5, 80),
            new EventItem("Backstage Pass", 15, 10),
            new EventItem("Backstage Pass", 10, 10),
            new EventItem("Backstage Pass", 5, 10),
            new EventItem("Backstage Pass", -1, 10),
            new ConjuredItem("Conjured", 5, 10),
        };

        public IList<Item> getInventory()
        {
            return this.items;
        }

        public void saveInventory(IList<Item> items)
        {
            this.items = items;
        }
    }
}