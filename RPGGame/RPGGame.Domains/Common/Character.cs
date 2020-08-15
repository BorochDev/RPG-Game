using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Domains.Common
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int AtackPoints { get; set; }
        public int ArmorPoints { get; set; }

    }
}
