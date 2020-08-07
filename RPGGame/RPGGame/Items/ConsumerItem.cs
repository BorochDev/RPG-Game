using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame
{
    public class ConsumerItem : Item
    {
        public int Quantity { get; set; }
        public int HPRestore { get; set; }
        public int SPRestore { get; set; }
        public int MyProperty { get; set; }
    }
}
