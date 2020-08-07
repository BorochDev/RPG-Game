using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame
{
    public class Player : Character
    {
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int ExperienceToNewLevel { get { return (int)Math.Pow(1.5, Level) * 100; }}
        public int StaminaPoints { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public List<ArmamentItem> ArmamentBackpack { get; set; }
        public List<ConsumerItem> ConsumerBackpack { get; set; }
        private ArmamentItem[] equipedArmament = new ArmamentItem[6];
        public ArmamentItem[] EquipedArmament { get 
            {
                return equipedArmament;
            }}

    }
}
