using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame
{
    public class ArmamentItem : Item
    {
        public int ArmorPoints { get; set; }
        public int WeaponDamage { get; set; }
        public int StrengthAdd { get; set; }
        public int StaminaAdd { get; set; }
        public int IntelligenceAdd { get; set; }
        public int Durability { get; set; }

    }
}
