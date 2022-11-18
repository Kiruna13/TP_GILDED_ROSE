using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class InMermoryItemsRepository : ItemsRepository
    {
        private IList<Item> items = new List<Item>(){
            new GenericItem("Wang", 10, 9, 12),
            new GenericItem("Sword", -1, 8, 15),
            new GenericItem("Shield", -1, 0, 15),
            new AgingItem("Aged Brie", 5, 4, 13),
            new AgingItem("Aged Brie", 5, 50, 20),
            new LegendaryItem("Sulfuras", 5, 80, 45),
            new EventItem("Backstage Pass", 15, 10, 13),
            new EventItem("Backstage Pass", 10, 10, 10),
            new EventItem("Backstage Pass", 5, 10, 14),
            new EventItem("Backstage Pass", -1, 10, 5),
            new ConjuredItem("Conjured", 5, 10, 27),
        };

        public IList<Item> getInventory()
        {
            return this.items;
        }

        public void saveInventory(IList<Item> items)
        {
            this.items = items;
        }

        public Item FindItems(string type, int quality)
        {
            return getInventory().FirstOrDefault(item => item.name == type && item.quality == quality);
        }
    }
}