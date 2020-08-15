using RPGGame.Domains.Common;
using RPGGame.Domains.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Domains.Entity
{
    public class ConsumerItem : Item
    {
        public int Quantity { get; set; }
        public int SPRestore { get; set; }
        public ConsumerType Type { get; set; }
    }
}
