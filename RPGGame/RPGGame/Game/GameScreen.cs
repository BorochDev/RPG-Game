using RPGGame.Characters;
using RPGGame.Items;
using RPGGame.Places;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Game
{
    public class GameScreen
    {
        readonly PlaceService placeService;
        readonly PlayerService playerService;
        readonly GameService gameService;
        

        private bool isParsed = false;
        private bool endGame = false;
        private bool endAction = false;

        private int StaminaUse;

        public GameScreen()
        {
            placeService = new PlaceService();
            playerService = new PlayerService();
            gameService = new GameService();
            
        }

        public void Start()
        {
            //pokazuje napisy początkowe i wprowadzenie do gry
            do
            {
                Console.WriteLine("Witaj w świecie wspaniałych przygód i wielu niebezpieczeństw.");
                Console.WriteLine("Mam nadzieję, że nie zginiesz tak łatwo!");

                Console.WriteLine();

                Console.Write("Podaj swoje imie poszukiwaczu: ");
                playerService.CreateNewPlayer();
                MainScreen();

                Console.Clear();

            } while (!isParsed);
            Console.Clear();
            Console.WriteLine("Dzięki za zagranie w moją gre! Mam nadzieję, że Ci się podobała");
            Console.ReadKey();

        }
        public void MainScreen()
        {
            //podstawowe okno dialogowe z wyborem akcji do wykonania oraz podstawowymi danymi danymi
            while (!endGame)
            {
                playerService.ShowBasicData();

                Console.WriteLine($"A więc co planujesz teraz zrobić?");
                Console.WriteLine("1) Wyrusz na przygode");
                Console.WriteLine("2) Rozwiń swoją kryjówke");
                Console.WriteLine("3) Odpocznij");
                Console.WriteLine("4) Zobacz do plecaka");
                Console.WriteLine("5) wyjdź z gry");

                switch (gameService.GetIntKeyDown(1,5, out isParsed))
                {
                    case 1:
                        Travel();
                        break;
                    case 2:
                        Build();
                        break;
                    case 3:
                        Rest();
                        break;
                    case 4:
                        OpenBackpack();
                        break;
                    case 5:
                        EndGame();
                        break;
                    default:
                        break;
                }
            }
            
        }

        

        private void Travel()
        {
            int Choice;
            do
            {
                playerService.ShowBasicData();
                //dodać losowy przydział surowców, losowe walki

                Console.WriteLine("Wybierz cel swojej podróży:");
                Console.WriteLine();

                placeService.ShowPlaceTableData();

                Console.WriteLine("7) Wróć do menu");

                Choice = gameService.GetIntKeyDown(1, 7,out isParsed);
                if (Choice >= 1 && Choice <= 6)
                {
                    
                    if (placeService.StaminaCheck(Choice, playerService.GetStamina(), out StaminaUse))
                    {
                        playerService.UseStamina(StaminaUse);
                        
                        placeService.Travelling(Choice);
                        playerService.AddMaterialsToBackpack(placeService.GetMaterials(Choice,
                            playerService.GetMultipliers()));
                        
                    }
                    else
                    {
                        playerService.ShowBasicData();
                        Console.WriteLine("Nie możesz się tam udać jesteś zyt zmęczony!");
                        Console.ReadKey();
                        isParsed = false;
                    }
                }
                else if (Choice==7)
                {
                    isParsed = true;
                }

            } while (!isParsed);
        } 

        private void Build()
        {
            int Choice;
            isParsed = false;
            while (!isParsed)
            {
                playerService.ShowBasicData();
                playerService.ShowBuilding();
                Choice = gameService.GetIntKeyDown(1, 4, out isParsed);
                if (Choice<4)
                {
                    playerService.Build(Choice);
                }
                else if (Choice == 4)
                {
                    isParsed = true;
                }
            }

        }

        private void Rest()
        {
            int Choice;
            isParsed = false;
            while (!isParsed)
            {
                playerService.ShowBasicData();

                Console.WriteLine("1) drzemka (+5 SP   15sek)");
                Console.WriteLine("2) krótki sen (+10 SP   30sek)");
                Console.WriteLine("3) sen (+20 SP   45sek)");
                Console.WriteLine("4) Długi sen (+100 SP   100sek)");
                Console.WriteLine("5) powrót");
                Choice = gameService.GetIntKeyDown(1, 5, out isParsed);
                if (Choice<5)
                {
                    playerService.Sleep(Choice);
                }
                else if (Choice==5)
                {
                    isParsed = true;
                }
            }
        }
        private void OpenBackpack()
        {

            int Choice;

            while (!endAction)
            {
                playerService.ShowBasicData();
                playerService.ShowConsumentBackpack();
                Console.WriteLine("9) powrót");
                Choice = gameService.GetIntKeyDown(0, 9, out isParsed);
                
                if (Choice>0&&Choice<9)
                {
                    playerService.UseItem(Choice);
                }
                else if (Choice == 9)
                {
                    endAction = true;
                }


            }
            endAction = false;

        }

        private void EndGame()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Czy napewno chcesz zakończyć grę?");
                Console.WriteLine("1)Tak");
                Console.WriteLine("2)Nie");
                if (gameService.GetIntKeyDown(1, 2, out isParsed) == 1)
                {
                    endGame = true;
                }
            } while (!isParsed);
        }
    }
}
