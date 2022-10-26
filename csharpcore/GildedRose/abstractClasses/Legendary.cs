namespace GildedRoseKata
{
    class Legendary : Item
    {
        public Legendary(string name, int sellIn, int quality)
			: base(name, sellIn, quality)
        {
			
        }
        public override void update()
        {
            quality = 80;
        }
    }
}