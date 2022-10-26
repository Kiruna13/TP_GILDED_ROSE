namespace GildedRoseKata
{
    class Cheese : Item
    {
        public Cheese(string name, int sellIn, int quality)
			: base(name, sellIn, quality)
        {
			
        }

        public override void update()
        {
            quality++;
        }
    }
} 

