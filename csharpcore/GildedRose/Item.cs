namespace GildedRoseKata
{
	/// <summary>
	/// class item
	/// </summary>
	public class Item
	{
		private string name;
		private int sellIn;
		private int quality;
		private bool isConjured;
		public Item(string name, int sellIn, int quality, bool isConjured)
		{
			this.name = name;
			this.sellIn = sellIn;
			this.quality = quality;
			this.isConjured = isConjured;
		}

		public void updateQuality(){
			
			switch(name)
			{
				case "Aged Brie":
					quality ++;
					break;
				case "Backstage passes":
				
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
					break;
				default:
					if(sellIn > 0)
					{
						sellIn--;
						quality--;
					}
					else
					{
						quality = quality-2;
					}
					break;
			}
			

			
		}
		public void checkQuality()
		{
			if(quality < 0){
				quality = 0;
			}
			if(quality > 50){
				quality = 50;
			}
			if(name == "sulfuras"){
				quality = 80;
			}
		}
		

}
}
