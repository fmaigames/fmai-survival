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
        public static bool CanPay(InventorySystem inventory, IEnumerable<BuildCost> costs)
        {
            if (inventory == null || costs == null) return false;
            foreach (var cost in costs)
            {
                if (cost == null || cost.amount < 0 || inventory.Count(cost.itemId) < cost.amount)
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
