namespace GildedRoseKata
{
    class Conjured : Item
    {
        public Conjured(string name, int sellIn, int quality)
			: base(name, sellIn, quality)
        {
			
        }

        public override void update()
        {
            quality -= 2;
        }
    }
} 

