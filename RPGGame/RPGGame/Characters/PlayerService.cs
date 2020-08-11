using RPGGame.Buildings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPGGame.Characters
{
    class PlayerService
    {

        private Player player;
        private readonly BuildingService buildingService = new BuildingService();

        public void CreateNewPlayer()
        {
            player = new Player()
            {
                Name = Console.ReadLine(),

                StaminaPoints = 100,
                Multipliers = new PlayerMultiplier()
                {
                    GatheringMultiplier = 1.0,
                    HuntingMultipier = 1.0,
                    MiningMultiplier = 1.0
                },
                ConsumerBackpack = new List<ConsumerItem>()
            };
        }

        

        public void ShowBasicData()
        {
            Console.Clear();
            Console.WriteLine($"Stamina: {player.StaminaPoints}");
            Console.WriteLine();
        }

        public int GetStamina()
        {
            return player.StaminaPoints;
        }
        
        public void UseStamina(int StaminaUse)
        {
            player.StaminaPoints -= StaminaUse;
        }

        public PlayerMultiplier GetMultipliers()
        {
            PlayerMultiplier playerMultiplier = player.Multipliers;
            PlayerMultiplier buildingMultiplier = buildingService.GetBuildingsMultipliers();

            playerMultiplier.GatheringMultiplier += buildingMultiplier.GatheringMultiplier;
            playerMultiplier.HuntingMultipier += buildingMultiplier.HuntingMultipier;
            playerMultiplier.MiningMultiplier += buildingMultiplier.MiningMultiplier;
            

            return playerMultiplier;
        }

        public void AddMaterialsToBackpack(List<ConsumerItem> MaterialsGet)
        {
            bool isOwned;
            foreach (var getMaterial in MaterialsGet)
            {
                if (getMaterial.Quantity <1)
                {
                    continue;
                }
                isOwned = false;
                foreach (var backpackItem in player.ConsumerBackpack)
                {
                    if (backpackItem.ItemID == getMaterial.ItemID)
                    {
                        backpackItem.Quantity += getMaterial.Quantity;
                        isOwned = true;
                        break;
                    }
                }
                if (!isOwned)
                {
                    player.ConsumerBackpack.Add(getMaterial);
                }
            }
        }

        public void ShowConsumentBackpack()
        {
            ShowBasicData();
            foreach (var item in player.ConsumerBackpack)
            {
                Console.Write($"{item.ItemID}) {item.Name}   ");
                if (item.SPRestore>0)
                {
                    Console.Write($"SP: {item.SPRestore}   ");
                }
                Console.WriteLine($"Ilość: {item.Quantity}");
            }
        }

        public void UseItem(int id)
        {
            foreach (var item in player.ConsumerBackpack)
            {
                if (item.ItemID == id && item.Quantity>0 && item.SPRestore > 0)
                {
                    player.StaminaPoints += item.SPRestore;
                    if (player.StaminaPoints>100)
                    {
                        player.StaminaPoints = 100;
                    }
                    item.Quantity--;
                }
            }
        }

        public void Sleep(int option)
        {
            switch (option)
            {
                case 1:
                    for (int i = 15; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine($"Pozostały czas snu: {i}");
                        Thread.Sleep(1000);
                    }
                    player.StaminaPoints +=5;
                    if (player.StaminaPoints > 100)
                    {
                        player.StaminaPoints = 100;
                    }
                    break;
                case 2:
                    for (int i = 30; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine($"Pozostały czas snu: {i}");
                        Thread.Sleep(1000);
                    }
                    player.StaminaPoints +=10;
                    if (player.StaminaPoints > 100)
                    {
                        player.StaminaPoints = 100;
                    }
                    break;
                case 3:
                    for (int i = 45; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine($"Pozostały czas snu: {i}");
                        Thread.Sleep(1000);
                    }
                    player.StaminaPoints +=20;
                    if (player.StaminaPoints > 100)
                    {
                        player.StaminaPoints = 100;
                    }
                    break;
                case 4:
                    for (int i = 100; i > 0; i--)
                    {
                        Console.Clear();
                        Console.WriteLine($"Pozostały czas snu: {i}");
                        Thread.Sleep(1000);
                    }
                    player.StaminaPoints +=100;
                    if (player.StaminaPoints>100)
                    {
                        player.StaminaPoints = 100;
                    }
                    break;
                default:
                    break;
            }

        }

        public void ShowBuilding()
        {
            buildingService.ShowBuildings();
        }
        public void Build(int id)
        {
            int[] sources = getSources();
            buildingService.Build(sources[0], sources[1], sources[2], sources[3], id);
        }

        private int[] getSources()
        {
            int[] sources = new int[4];
            foreach (var item in player.ConsumerBackpack)
            {
                if (item.ItemID == 2)
                {
                    sources[0] = item.Quantity;
                }
                else if (item.ItemID == 3)
                {
                    sources[1] = item.Quantity;
                }
                else if (item.ItemID == 4)
                {
                    sources[3] = item.Quantity;
                }
                else if (item.ItemID == 7)
                {
                    sources[2] = item.Quantity;
                }
            }
            return sources;
        }
    }
}
