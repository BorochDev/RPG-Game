using RPGGame.Domains.Entity;
using RPGGame.Domains.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.App.Concrete
{
    public class BuildingService
    {
        private readonly Building[] buildings = new Building[3];

        public BuildingService()
        {
            buildings[0] = new Building()
            {
                BuildingID = 1,
                Level = 0,
                Name = "Tartak",
                Requirement = new Requirement(35,20,5,10),
                Multiplier = new Multiplier
                {
                    GatheringMultiplier = 0,
                    MiningMultiplier = 0,
                    HuntingMultipier = 0
                }
            };
            buildings[1] = new Building
            {
                BuildingID = 2,
                Level = 0,
                Name = "Kamieniołom",
                Requirement = new Requirement(25,40,10,20),
                Multiplier = new Multiplier
                {
                    MiningMultiplier = 2,
                    HuntingMultipier = 0,
                    GatheringMultiplier = 0
                }

            };
            buildings[2] = new Building
            {
                BuildingID = 3,
                Level = 0,
                Name = "Wieża strzelnicza",
                Requirement = new Requirement(35,15,20,15),
                Multiplier = new Multiplier
                {
                    HuntingMultipier = 2,
                    MiningMultiplier = 0,
                    GatheringMultiplier = 0
                }
            };
        }

        public void ShowBuildings()
        {
            foreach (var item in buildings)
            {
                 Console.WriteLine($"{item.BuildingID}) {item.Name}   kamień: {item.Requirement.RequirementStone}" +
                        $"   drewno: {item.Requirement.RequirementWood}  ");
                 Console.WriteLine($"            woda: {item.Requirement.RequirementWater}" +
                     $"   żelazo: {item.Requirement.RequirementIron}   Level: {item.Level}");
                 Console.WriteLine();
            }
            Console.WriteLine("4) powrót");
        }

        public Requirement Build(Requirement sources, int id)
        {
            foreach (var item in buildings)
            {
                if (item.BuildingID == id)
                {
                    if (sources.RequirementWood >= item.Requirement.RequirementWood &&
                        sources.RequirementStone >= item.Requirement.RequirementStone &&
                        sources.RequirementWater >= item.Requirement.RequirementWater &&
                        sources.RequirementIron >= item.Requirement.RequirementIron)
                    {
                        item.Level++;
                        sources = item.Requirement;

                        item.Requirement.RequirementIron *= 2;
                        item.Requirement.RequirementStone *= 2;
                        item.Requirement.RequirementWater *= 2;
                        item.Requirement.RequirementWood *= 2;

                        switch (item.BuildingID)
                        {
                            case 1:
                                item.Multiplier.GatheringMultiplier += 1.25;
                                break;
                            case 2:
                                item.Multiplier.MiningMultiplier += 1.25;
                                break;
                            case 3:
                                item.Multiplier.HuntingMultipier += 1.25;
                                break;
                            default:
                                break;
                        }

                        Console.Clear();
                        Console.WriteLine($"Udało ci się rozbudować {item.Name}");
                        Console.ReadKey();
                        return sources;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nie masz wystarczająco dużo surowców");
                        Console.ReadKey();
                        return new Requirement(0,0,0,0);
                    }
                }
            }
            return new Requirement(0,0,0,0);
        }

        public Multiplier GetBuildingsMultipliers()
        {
            Multiplier multiplier = new Multiplier()
            {
                GatheringMultiplier = 0,
                HuntingMultipier = 0,
                MiningMultiplier = 0
            };

            for (int i = 0; i < 3; i++)
            {
                 multiplier.GatheringMultiplier += buildings[i].Multiplier.GatheringMultiplier;
                 multiplier.MiningMultiplier += buildings[i].Multiplier.MiningMultiplier;
                 multiplier.HuntingMultipier += buildings[i].Multiplier.HuntingMultipier;
            }


            return multiplier;
        }

    }
}
