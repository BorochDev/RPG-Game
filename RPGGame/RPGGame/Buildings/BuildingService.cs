using RPGGame.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Buildings
{
    public class BuildingService
    {
        private readonly Building[] buildings = new Building[3];

        public BuildingService()
        {

            buildings[0] = new Building
            {
                BuildingID = 1,
                IsBuilded = false,
                Name = "Tartak",
                RequirementIron = 5,
                RequirementStone = 30,
                RequirementWater = 10,
                RequirementWood = 50,
                Multiplier = new PlayerMultiplier
                {
                    GatheringMultiplier = 2,
                    MiningMultiplier = 0,
                    HuntingMultipier = 0
                }
            };
            buildings[1] = new Building
            {
                BuildingID = 2,
                IsBuilded = false,
                Name = "Kamieniołom",
                RequirementIron = 15,
                RequirementStone = 70,
                RequirementWater = 20,
                RequirementWood = 40,
                Multiplier = new PlayerMultiplier
                {
                    MiningMultiplier = 2,
                    HuntingMultipier = 0,
                    GatheringMultiplier = 0
                }

            };
            buildings[2] = new Building
            {
                BuildingID = 3,
                IsBuilded = false,
                Name = "Wieża strzelnicza",
                RequirementIron = 20,
                RequirementStone = 20,
                RequirementWater = 15,
                RequirementWood = 70,
                Multiplier = new PlayerMultiplier
                {
                    HuntingMultipier = 2,
                    MiningMultiplier = 0,
                    GatheringMultiplier = 0
                }
            };
        }

        public PlayerMultiplier GetBuildingsMultipliers()
        {
            PlayerMultiplier multiplier = new PlayerMultiplier() {
            GatheringMultiplier = 0,
            HuntingMultipier = 0,
            MiningMultiplier = 0
            };

            for (int i = 0; i < 3; i++)
            {
                if (!buildings[i].IsBuilded)
                {
                    multiplier.GatheringMultiplier += buildings[i].Multiplier.GatheringMultiplier;
                    multiplier.MiningMultiplier += buildings[i].Multiplier.MiningMultiplier;
                    multiplier.HuntingMultipier += buildings[i].Multiplier.HuntingMultipier;
                }
            }

            
            return multiplier;
        }

        public void ShowBuildings()
        {
            foreach (var item in buildings)
            {

                if (!item.IsBuilded)
                {
                    Console.WriteLine($"{item.BuildingID}) {item.Name}   kamień: {item.RequirementStone}" +
                        $"   drewno: {item.RequirementWood}  ");
                    Console.WriteLine($"            woda: {item.RequirementWater}   żelazo: {item.RequirementIron}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("4) powrót");
        }

        public int[] Build(int wood, int stone, int water, int iron, int id)
        {
            foreach (var item in buildings)
            {
                if (item.BuildingID == id)
                {
                    if (wood >= item.RequirementWood && stone >= item.RequirementStone &&
                        water >=item.RequirementWater && iron >= item.RequirementIron)
                    {
                        item.IsBuilded = true;
                        Console.Clear();
                        Console.WriteLine($"Udało ci się rozbudować {item.Name}");
                        Console.ReadKey();
                        return new int[] { item.RequirementWood, item.RequirementStone,
                                           item.RequirementWater, item.RequirementIron};
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nie masz wystarczająco dużo surowców");
                        Console.ReadKey();
                        return new int[] { 0, 0, 0, 0 };
                    }
                }
            }
            return new int[] {0,0,0,0};
        }
    }
}
