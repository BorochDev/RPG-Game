using RPGGame.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Buildings
{
    class Building
    {
        public int BuildingID { get; set; }
        public bool IsBuilded { get; set; }
        public string Name { get; set; }
        public int RequirementWood { get; set; }
        public int RequirementStone { get; set; }
        public int RequirementIron { get; set; }
        public int RequirementWater { get; set; }
        public PlayerMultiplier Multiplier { get; set; }

    }
}
