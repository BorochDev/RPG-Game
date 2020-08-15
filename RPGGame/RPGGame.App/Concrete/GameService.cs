using RPGGame.Domains.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.App.Concrete
{
    public  class GameService
    {
        private readonly PlaceService placeService = new PlaceService();
        private readonly PlayerService playerService = new PlayerService();
        private readonly BattleService battleService = new BattleService();

        private  bool isParsed;
        private  bool endAction;

        public static int GetIntKeyDown(int min, int max, out bool isParsed)
        {
            int choice;
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice))
            {
                if (choice >= min && choice <= max)
                {
                    isParsed = true;
                }
                else
                {
                    isParsed = false;
                    choice = 0;
                }
            }
            else
            {
                isParsed = false;
                choice = 0;
            }
            Console.Clear();
            return choice;
        }

        public  void CreatePlayer()
        {
            playerService.CreateNewPlayer();
        }

        public  void ShowPlayerData()
        {
            playerService.ShowBasicData();
        }

        public  void Travel()
        {
            int StaminaUse;
            int Choice;
            bool meetAnimal;

            do
            {
                playerService.ShowBasicData();
                //dodać losowy przydział surowców, losowe walki

                Console.WriteLine("Wybierz cel swojej podróży:");
                Console.WriteLine();

                placeService.ShowPlaceTableData();

                Console.WriteLine("7) Wróć do menu");

                Choice = GetIntKeyDown(1, 7, out isParsed);
                if (Choice >= 1 && Choice <= 6)
                {

                    if (placeService.StaminaCheck(Choice, playerService.GetStamina(), out StaminaUse))
                    {
                        playerService.UseStamina(StaminaUse);

                        meetAnimal = playerService.MeetAnimal();

                        if (meetAnimal)
                        {
                            BattleData battleData = playerService.GetBattleData();
                            battleService.StartBattle(battleData);
                            if (playerService.GetHP() > 0) 
                            {
                                placeService.Travelling(Choice);
                                playerService.AddMaterialsToBackpack(placeService.GetMaterials(Choice,
                                    playerService.GetMultipliers()));
                            }
                            else
                            {
                                playerService.Dead();
                            }
                        }
                        else
                        {
                            placeService.Travelling(Choice);
                            playerService.AddMaterialsToBackpack(placeService.GetMaterials(Choice,
                                playerService.GetMultipliers()));
                        }



                    }
                    else
                    {
                        playerService.ShowBasicData();
                        Console.WriteLine("Nie możesz się tam udać jesteś zyt zmęczony!");
                        Console.ReadKey();
                        isParsed = false;
                    }
                }
                else if (Choice == 7)
                {
                    isParsed = true;
                }

            } while (!isParsed);
        }

        public   void Build()
        {
            int Choice;
            isParsed = false;
            while (!isParsed)
            {
                playerService.ShowBasicData();
                playerService.ShowBuilding();
                Choice = GetIntKeyDown(1, 4, out isParsed);
                if (Choice < 4)
                {
                    playerService.Build(Choice);
                }
                else if (Choice == 4)
                {
                    isParsed = true;
                }
            }

        }

        public  void Rest()
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
                Choice = GetIntKeyDown(1, 5, out isParsed);
                if (Choice < 5)
                {
                    playerService.Sleep(Choice);
                }
                else if (Choice == 5)
                {
                    isParsed = true;
                }
            }
        }

        public  void OpenBackpack()
        {

            int Choice;

            while (!endAction)
            {
                playerService.ShowBasicData();
                playerService.ShowConsumentBackpack();
                Console.WriteLine("9) powrót");
                Choice = GetIntKeyDown(0, 9, out isParsed);

                if (Choice > 0 && Choice < 9)
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

        public  bool EndGame()
        {
            bool endGame = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Czy napewno chcesz zakończyć grę?");
                Console.WriteLine("1)Tak");
                Console.WriteLine("2)Nie");
                if (GetIntKeyDown(1, 2, out isParsed) == 1)
                {
                    endGame = true;
                }
            } while (!isParsed);
            return endGame;
        }
    }
}
