namespace GildedRoseKata
{
class Stage : Item
    {
        public Stage(string name, int sellIn, int quality)
			: base(name, sellIn, quality)
        {
			
        }
        public override void update()
        {
            switch (sellIn)
            {
                case <= 0:
                    quality = 0;
                    break;
                case <= 5:
                    quality += 3;
                    break;
                case <= 10:
                    quality += 2;
                    break;
                default:
                    quality++;
                    break;
            }
        }
    }
}