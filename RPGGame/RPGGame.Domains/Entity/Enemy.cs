using RPGGame.Domains.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Domains.Entity
{
    public class Enemy : Character
    {
        public ConsumerItem[] Loot { get; set; }
        public bool CanRunAway { get; set; }
    }
}
