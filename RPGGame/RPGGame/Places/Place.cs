using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Places
{
    public class Place
    {
        public string Name { get; set; }
        public int StaminaUse { get; set; }
        public bool IsWood { get; set; }
        public bool IsMine { get; set; }
        public bool IsPlant { get; set; }
        public bool IsWater { get; set; }
        public bool IsAnimal { get; set; }
    }
}
