using RPGGame.Domains.Entity;
using RPGGame.Domains.Helpers;
using System;
using System.Linq;
using System.Threading;

namespace RPGGame.App.Concrete
{
    public class BattleService
    {
        private readonly Enemy[] enemies = new Enemy[6];
        private readonly ConsumerItemService consumerService = new ConsumerItemService();

        public BattleService()
        {
            ConsumerItem[] consumerItem = new ConsumerItem[2];
            Random random = new Random();
            consumerItem[0] = consumerService.GetTemplateItem(1, random.Next(0, 4));
            consumerItem[1] = consumerService.GetTemplateItem(6, random.Next(0, 5));
            enemies[0] = new Enemy
            {
                Name = "Wilk",
                HP = 25,
                ArmorPoints = 5,
                AtackPoints = 10,
                Loot = consumerItem,
                CanRunAway = false
            };
            consumerItem[0] = consumerService.GetTemplateItem(1, random.Next(0, 3));
            consumerItem[1] = consumerService.GetTemplateItem(6, random.Next(0, 5));
            enemies[1] = new Enemy
            {
                Name = "Dziki pies",
                HP = 15,
                ArmorPoints = 5,
                AtackPoints = 5,
                Loot = consumerItem,
                CanRunAway = true
            };
            consumerItem[0] = consumerService.GetTemplateItem(1, random.Next(0, 6));
            consumerItem[1] = consumerService.GetTemplateItem(6, random.Next(0, 6));
            enemies[2] = new Enemy
            {
                Name = "Niedźwiedź",
                HP = 40,
                ArmorPoints = 15,
                AtackPoints = 15,
                Loot = consumerItem,
                CanRunAway = true
            };
            consumerItem[0] = consumerService.GetTemplateItem(1, random.Next(0, 4));
            consumerItem[1] = consumerService.GetTemplateItem(6, random.Next(0, 5));
            enemies[3] = new Enemy
            {
                Name = "Owca",
                HP = 15,
                ArmorPoints = 0,
                AtackPoints = 5,
                Loot = consumerItem,
                CanRunAway = true
            };
            consumerItem[0] = consumerService.GetTemplateItem(1, random.Next(0, 2));
            consumerItem[1] = consumerService.GetTemplateItem(6, random.Next(0, 5));
            enemies[4] = new Enemy
            {
                Name = "pancernik",
                HP = 15,
                ArmorPoints = 30,
                AtackPoints = 5,
                Loot = consumerItem,
                CanRunAway = true
            };
            consumerItem[0] = consumerService.GetTemplateItem(1, random.Next(0, 8));
            consumerItem[1] = consumerService.GetTemplateItem(6, random.Next(0, 7));
            enemies[5] = new Enemy
            {
                Name = "Król Lasu",
                HP = 50,
                ArmorPoints = 25,
                AtackPoints = 30,
                Loot = consumerItem,
                CanRunAway = false
            };

        }

        public BattleData StartBattle(BattleData player)
        {
            Random random = new Random();
            Enemy enemy = enemies[random.Next(0, 5)];
            bool isParsed = false;
            int Choice = 0;
            int atack;


            Console.Clear();
            Console.WriteLine($"Podczas swojej podróży napotykasz się na {enemy.Name}");
            Console.WriteLine("Chyba nie jest zbyt zadowolony twoją obecnością.  Lepiej na siebie uważaj");
            Console.ReadKey();
            while (!isParsed)
            {
                Console.Clear();
                Console.WriteLine("1)Walka");
                Console.WriteLine("2)Ucieczka");
                Choice = GameService.GetIntKeyDown(1, 2, out isParsed);
            }
            switch (Choice)
            {
                case 1:
                    while (player.HP > 0 && enemy.HP > 0)
                    {

                        atack = (int)(random.Next(50, 200) / 100 * player.AtackPoints)
                                - (int)(random.NextDouble() * enemy.ArmorPoints / 2);
                        Console.WriteLine($"{enemy.Name} otrzymuje {atack} obrażeń");
                        enemy.HP -= atack;
                        Thread.Sleep(1500);
                        if (enemy.HP > 0)
                        {
                            atack = (int)(random.Next(50, 200) / 100 * enemy.AtackPoints)
                                    - (int)(random.NextDouble() * player.ArmorPoints / 2);
                            Console.WriteLine($"{player.Name} otrzymuje {atack} obrażeń");
                            player.HP -= atack;
                            Thread.Sleep(1500);
                        }
                    }
                    break;
                case 2:
                    if (enemy.CanRunAway)
                    {
                        Console.Clear();
                        Console.WriteLine("Tym razem udało ci się uciec.");
                        Console.ReadKey();
                        return player;
                    }
                    else
                    {

                        Console.WriteLine("Biegłeś ile sił w nogach ale niestety");
                        Console.WriteLine("byłeś zbyt wolny... musisz walczyć!");
                        Console.ReadKey();
                        while (player.HP > 0 && enemy.HP > 0)
                        {
                            Console.Clear();
                            atack = (int)(random.Next(50, 200) / 100 * enemy.AtackPoints)
                                    - (int)(random.NextDouble() * player.ArmorPoints / 2);
                            Console.WriteLine($"{player.Name} otrzymuje {atack} obrażeń");
                            player.HP -= atack;
                            Thread.Sleep(1500);
                            atack = (int)(random.Next(50, 200) / 100 * player.AtackPoints)
                                    - (int)(random.NextDouble() * enemy.ArmorPoints / 2);
                            Console.WriteLine($"{enemy.Name} otrzymuje {atack} obrażeń");
                            enemy.HP -= atack;
                            Thread.Sleep(1500);
                        }
                    }
                    break;
                default:
                    break;
            }

            if (player.HP > 0)
            {
                Console.WriteLine($"Gratulacje udało ci się pokonać {enemy.Name}");
                player.ConsumerLoot = enemy.Loot.ToList();
            }

            Console.ReadKey();
            return player;
        }
    }
}
