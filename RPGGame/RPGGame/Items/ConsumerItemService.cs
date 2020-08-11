using System;
using System.Collections.Generic;
using System.Text;

namespace RPGGame.Items
{
    class ConsumerItemService
    {
        private readonly ConsumerItem[] consumerItemTable = new ConsumerItem[9];

        public ConsumerItemService()
        {
            consumerItemTable[0] = new ConsumerItem() {
                ItemID = 1,
                Name = "Surowe mięso",
                SPRestore = 5,
                Type = ConsumerType.of_consumer
            };

            consumerItemTable[1] = new ConsumerItem()
            {
                ItemID = 2,
                Name = "Drewno",
                SPRestore = 0,
                Type = ConsumerType.neutral
            };

            consumerItemTable[2] = new ConsumerItem()
            {
                ItemID = 3,
                Name = "Kamień",
                SPRestore = 0,
                Type = ConsumerType.neutral
            };

            consumerItemTable[3] = new ConsumerItem()
            {
                ItemID = 4,
                Name = "żelazo",
                SPRestore = 0,
                Type = ConsumerType.neutral
            };

            consumerItemTable[4] = new ConsumerItem()
            {
                ItemID = 5,
                Name = "Owoce",
                SPRestore = 5,
                Type = ConsumerType.of_consumer
            };

            consumerItemTable[5] = new ConsumerItem()
            {
                ItemID = 6,
                Name = "Skóra",
                SPRestore = 0,
                Type = ConsumerType.neutral
            };

            consumerItemTable[6] = new ConsumerItem()
            {
                ItemID = 7,
                Name = "Butelka wody",
                SPRestore = 15,
                Type = ConsumerType.of_consumer
            };

            consumerItemTable[7] = new ConsumerItem()
            {
                ItemID = 8,
                Name = "Ugotowane mięso",
                SPRestore = 15,
                Type = ConsumerType.of_consumer
            };
        }

        public ConsumerItem GetTemplateItem(int ID, int quantity)
        {
            ConsumerItem consumerItem = consumerItemTable[ID];
            consumerItem.Quantity = 1 + quantity;
            return consumerItem;
        }
    }
}
