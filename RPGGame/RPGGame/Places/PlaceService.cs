using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using RPGGame.Characters;
using RPGGame.Items;

namespace RPGGame.Places
{
    public class PlaceService
    {
        private readonly Place[] places = new Place[5];
        readonly ConsumerItemService consumerItemService;

        public PlaceService()
        {
            consumerItemService = new ConsumerItemService(); //dodanie listy przedmiotów dostępnych
                                                             //do zdobycia w wyprawach
            #region AddPlacesTable
            places[0] = new Place()
            {
                Name = "Wielkie stawy",
                StaminaUse = 5,
                IsAnimal = false,
                IsMine = false,
                IsPlant = true,
                IsWater = true,
                IsWood = false,

            };
            places[1] = new Place()
            {
                Name = "Górska przełęcz",
                StaminaUse = 10,
                IsAnimal = false,
                IsMine = true,
                IsPlant = false,
                IsWater = false,
                IsWood = true,

            };
            places[2] = new Place()
            {
                Name = "Bagna",
                StaminaUse = 20,
                IsAnimal = true,
                IsMine = false,
                IsPlant = true,
                IsWater = true,
                IsWood = false,

            };
            places[3] = new Place()
            {
                Name = "Serce Lasu",
                StaminaUse = 15,
                IsAnimal = true,
                IsMine = false,
                IsPlant = true,
                IsWater = false,
                IsWood = true,

            };
            places[4] = new Place()
            {
                Name = "Mroczna jaskinia",
                StaminaUse = 15,
                IsAnimal = true,
                IsMine = true,
                IsPlant = false,
                IsWater = false,
                IsWood = false,
            };

            #endregion
        }

        public void ShowPlaceTableData()
        {
            int id =1;
            foreach (var item in places)
            {
                Console.WriteLine($"{id}) {item.Name}" +
                    $"   Zużycie wytrzymałości: {item.StaminaUse}");
                id++;
                Console.WriteLine();
            }
        }
        public bool StaminaCheck(int PlaceID,int PlayerStamina, out int StaminaUse)
        {
            if (PlayerStamina < places[PlaceID-1].StaminaUse) 
            {
                StaminaUse = 0;

                return false;
            }
            else
            {
                StaminaUse = places[PlaceID-1].StaminaUse;

                return true;
            }
        }

        public void Travelling(int PlaceID)
        {
            PlaceID--;
            Console.Clear();
            for (int i = places[PlaceID].StaminaUse * 5; i > 0; i--)
            {
                Console.WriteLine($"Dotrzesz do celu podróży za: {i}");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public List<ConsumerItem> GetMaterials(int PlaceID, PlayerMultiplier Multipliers)
        {
            List<ConsumerItem> MaterialsGet = new List<ConsumerItem>();
            Random random = new Random();
            if (places[PlaceID].IsAnimal)
            {
                MaterialsGet.Add(consumerItemService.GetTemplateItem(0,
                    (int)(random.NextDouble() * 3 * Multipliers.HuntingMultipier)));
                MaterialsGet.Add(consumerItemService.GetTemplateItem(5,
                    (int)(random.NextDouble() * 6 * Multipliers.HuntingMultipier)));
            }
            if (places[PlaceID].IsMine)
            {
                MaterialsGet.Add(consumerItemService.GetTemplateItem(2,
                    (int)(random.NextDouble() * 8 * Multipliers.MiningMultiplier)));
                MaterialsGet.Add(consumerItemService.GetTemplateItem(3,
                    (int)(random.NextDouble() * 3 * Multipliers.MiningMultiplier)));
            }
            if (places[PlaceID].IsPlant)
            {
                MaterialsGet.Add(consumerItemService.GetTemplateItem(4,
                    (int)(random.NextDouble() * 5 * Multipliers.GatheringMultiplier)));
            }
            if (places[PlaceID].IsWater)
            {
                MaterialsGet.Add(consumerItemService.GetTemplateItem(6,
                    (int)(random.NextDouble() * 4 * Multipliers.GatheringMultiplier)));
            }
            if (places[PlaceID].IsWood)
            {
                MaterialsGet.Add(consumerItemService.GetTemplateItem(1,
                    (int)(random.NextDouble() * 7 * Multipliers.GatheringMultiplier)));
            }

            
            return MaterialsGet;
        }
    }
}
