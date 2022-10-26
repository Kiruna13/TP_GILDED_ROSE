namespace GildedRoseKata
{
    class Classic : Item
    {
        public Classic(string name, int sellIn, int quality)
			: base(name, sellIn, quality)
        {
			
        }

        public override void update()
        {
            sellIn--;
			quality--;
        }
    }
} 

