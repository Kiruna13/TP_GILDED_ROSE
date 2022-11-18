using System.Data.Common;
using GildedRoseKata;


namespace consoleUI
{

    public class ConsoleUI
    {
        static ItemsRepository itemRepository = new InMermoryItemsRepository();
        static Shop shop = new Shop(itemRepository);
        
        public static void Main(string[] args)
        {
            
            while (true)
            {
                AfficherLeMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        AfficherLesArticles();
                        break;
                    case "2":
                        Console.WriteLine("Voici le solde du shop : " + shop.Balance);
                        break;
                    case "3":
                        shop.UpdateInventory();
                        break;
                    case "4":
                        AfficherLesArticles();
                        Console.WriteLine("quel article souhaitez vous vendre ?");
                        string numArticle = Console.ReadLine();
                        shop.SellItem(itemRepository.getInventory().ElementAt(int.Parse(numArticle) - 1).name, itemRepository.getInventory().ElementAt(int.Parse(numArticle) - 1).quality);
                        itemRepository.getInventory();
                        break;
                    case "5":
                        
                        break;
                }
            }
        }
        public static void AfficherLeMenu()
        {
            Console.WriteLine("----- Bienvenue dans le shop guildedRose -----");
            Console.WriteLine("Que souhaitez vous faire ?");
            Console.WriteLine("1) Affichez la liste des articles");
            Console.WriteLine("2) Affichez le solde du magasin");
            Console.WriteLine("3) Lancer une mise à jour des articles ");
            Console.WriteLine("4) Vendre un article");
            Console.WriteLine("5) Quitter");
            Console.WriteLine("Entrez le numéro correspondant à votre choix :");
            
        }

        public static void AfficherLesArticles()
        {
            foreach (Item items in itemRepository.getInventory())
            {
                Console.WriteLine((itemRepository.getInventory().IndexOf(items) + 1 )+ ") Nom:" + items.name + ", Prix: $" + items.GetValue());
            }
        }
    }
}