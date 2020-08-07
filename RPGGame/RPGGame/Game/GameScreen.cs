using RPGGame.Places;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Game
{
    public static class GameScreen
    {
        private static Place[] places = new Place[6];

        private static bool isParsed = false;
        private static bool endGame = false;

        private static int Choice;
        

        public static void Start()
        {
            //tworzy dostępne lokacje
            #region AddPlacesTable
            places[0] = new Place()
            {
                Name = "Wielkie stawy",
                StaminaUse = 5,
                PrefereLevel = 1,
                EnemyType = EnemyState.friendly,
                IsAnimal = false,
                IsMine = false,
                IsPlant = true,
                IsWater = true,
                IsWood = false,
                IsZoneX = false
            };
            places[1] = new Place()
            {
                Name = "Górska przełęcz",
                StaminaUse = 10,
                PrefereLevel = 2,
                EnemyType = EnemyState.friendly,
                IsAnimal = false,
                IsMine = true,
                IsPlant = false,
                IsWater = false,
                IsWood = true,
                IsZoneX = false
            };
            places[2] = new Place()
            {
                Name = "Bagna",
                StaminaUse = 20,
                PrefereLevel = 4,
                EnemyType = EnemyState.neutral,
                IsAnimal = true,
                IsMine = false,
                IsPlant = true,
                IsWater = true,
                IsWood = false,
                IsZoneX = false
            };
            places[3] = new Place()
            {
                Name = "Serce Lasu",
                StaminaUse = 15,
                PrefereLevel = 7,
                EnemyType = EnemyState.aggressive,
                IsAnimal = true,
                IsMine = false,
                IsPlant = true,
                IsWater = false,
                IsWood = true,
                IsZoneX = false
            };
            places[4] = new Place()
            {
                Name = "Mroczna jaskinia",
                StaminaUse = 15,
                PrefereLevel = 10,
                EnemyType = EnemyState.aggressive,
                IsAnimal = true,
                IsMine = true,
                IsPlant = false,
                IsWater = false,
                IsWood = false,
                IsZoneX = false
            };
            places[5] = new Place()
            {
                Name = "Strefa X",
                StaminaUse = 25,
                PrefereLevel = 10,
                EnemyType = EnemyState.dead,
                IsAnimal = false,
                IsMine = false,
                IsPlant = false,
                IsWater = false,
                IsWood = false,
                IsZoneX = true
            };
            #endregion

            //pokazuje napisy początkowe i wprowadzenie do gry
            do
            {
                Console.WriteLine("Witaj w świecie wspaniałych przygód i wielu niebezpieczeństw.");
                Console.WriteLine("Mam nadzieję, że nie zginiesz tak łatwo!");
                Console.WriteLine("1) Nowa gra");
                Console.WriteLine("2) Wczytaj postać");

                Console.WriteLine();

                switch (GetIntKeyDown(1,2))
                {
                    case 1:
                        Console.Write("Podaj swoje imie poszukiwaczu: ");
                        Player player = new Player()
                        {
                            Name = Console.ReadLine().ToString(),
                            HealthPoints = 100,
                            StaminaPoints = 100,
                            Level = 1,
                            ArmorPoints = 0,
                            ExperiencePoints = 0,
                            Agility = 10,
                            Strength = 10,
                            Intelligence = 10,
                            ArmamentBackpack = null,
                            ConsumerBackpack = null
                        };
                        isParsed = true;
                        MainScreen(player);
                        break;

                    case 2:
                        Console.WriteLine("Opcja chwilowo niedostępna");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Nie ma takiej opcji, wybierz jeszcze raz");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();

            } while (!isParsed && !endGame);
            Console.Clear();
            Console.WriteLine("Dzięki za zagranie w moją gre! Mam nadzieję, że Ci się podobała");
            Console.ReadKey();

        }
        public static void MainScreen(Player player)
        {
            //podstawowe okno dialogowe z wyborem akcji do wykonania oraz podstawowymi danymi danymi
            while (!endGame)
            {
                ShowBasicData(player.HealthPoints, player.StaminaPoints, player.Level);

                Console.WriteLine($"A więc co planujesz teraz zrobić {player.Name}?");
                Console.WriteLine("1) Wyrusz na przygode");
                Console.WriteLine("2) Rozwiń swoją kryjówke");
                Console.WriteLine("3) Odpocznij");
                Console.WriteLine("4) Zobacz do plecaka");
                Console.WriteLine("5) Zapisz gre");
                Console.WriteLine("6) wyjdź z gry");

                switch (GetIntKeyDown(1,6))
                {
                    case 1:
                        Travel(player);
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        endGame = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Nie ma takiej opcji, wybierz jeszcze raz");
                        Console.ReadKey();
                        break;
                }
            }
            
        }

        private static int GetIntKeyDown(int min, int max)
        {
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out Choice))
            {
                if (Choice >= min && Choice <= max)
                {
                    isParsed = true;
                }
                else
                {
                    Choice = 0;
                }
            }
            else
            {
                Choice = 0;
            }
            return Choice;
        }

        private static void ShowBasicData(int HP, int SP, int Level)
        {
            Console.Clear();
            Console.WriteLine($"HP: {HP}   Stamina: {SP}     Level: {Level}");
            Console.WriteLine();
        }

        private static void Travel(Player player)
        {
            ShowBasicData(player.HealthPoints, player.StaminaPoints, player.Level);
            //dodać wybór lokacji, losowy przydział surowców, losowe walki
            int id = 1;
            Console.WriteLine("Wybierz cel swojej podróży:");
            foreach (var item in places)
            {
                Console.WriteLine($"{id}) {item.Name}   Level: {item.PrefereLevel},  " +
                    $" Zużycie wytrzymałości: {item.StaminaUse}");
                id++;
            }
            Console.Read();
        } 

        private static void Build(Player player)
        {
            ShowBasicData(player.HealthPoints, player.StaminaPoints, player.Level);
            //dodać liste budynków do rozbudowy oraz ich wymagania

        }

        private static void Rest(Player player)
        {
            ShowBasicData(player.HealthPoints, player.StaminaPoints, player.Level);
            //dodać różne długości snu wraz z wstrzymywaniem programu na dany czas

        }
        private static void OpenBackpack(Player player)
        {
            ShowBasicData(player.HealthPoints, player.StaminaPoints, player.Level);
            //wprowadzenie podziału na przedmiowy konsumpcyjne oraz wyposażenie

        }

    }
}
