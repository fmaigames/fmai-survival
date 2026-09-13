using System.Collections.Generic;
using FMAI.Survival.Inventory;
using UnityEngine;

namespace FMAI.Survival.Base
{
    [System.Serializable]
    public class BuildCost
    {
        public string itemId;
        public int amount = 1;
    }

    public static class BuildCostUtility
    {
        private static int ItemCount(InventorySystem inventory, string itemId)
        {
            if (inventory == null || string.IsNullOrWhiteSpace(itemId)) return 0;
            int count = 0;
            foreach (var item in inventory.Items)
                if (item == itemId) count++;
            return count;
        }

        public static bool CanPay(InventorySystem inventory, IEnumerable<BuildCost> costs)
        {
            if (inventory == null || costs == null) return false;
            foreach (var cost in costs)
            {
                if (cost == null || cost.amount < 0 || ItemCount(inventory, cost.itemId) < cost.amount)
                    return false;
            }
            return true;
        }

        public static bool Pay(InventorySystem inventory, IEnumerable<BuildCost> costs)
        {
            if (!CanPay(inventory, costs)) return false;
            foreach (var cost in costs)
                for (int i = 0; i < cost.amount; i++)
                    inventory.Remove(cost.itemId);
            return true;
        }
    }
}
