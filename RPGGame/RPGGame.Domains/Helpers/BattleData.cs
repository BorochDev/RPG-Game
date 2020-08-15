using RPGGame.Domains.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Domains.Helpers
{
    public class BattleData
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int AtackPoints { get; set; }
        public int ArmorPoints { get; set; }
        public List<ConsumerItem> ConsumerLoot { get; set; }
    }
}
