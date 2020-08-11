using RPGGame.Buildings;
using RPGGame.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame
{
    public class Player : Character
    {
        public int StaminaPoints { get; set; }
        public PlayerMultiplier Multipliers { get; set; }
        public List<ConsumerItem> ConsumerBackpack { get; set; }

    }
}
