using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Domains.Common
{
    public abstract class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
