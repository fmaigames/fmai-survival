using FMAI.Survival.Inventory;
using UnityEngine;

namespace FMAI.Survival.Crafting
{
    public class CraftingSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;

        public bool CraftBandage()
        {
            if (inventory == null) return false;
            if (!inventory.Has("item.cloth") || !inventory.Has("item.herb")) return false;
            inventory.Remove("item.cloth");
            inventory.Remove("item.herb");
            return inventory.Add("item.bandage");
        }

        public bool CraftFood()
        {
            if (inventory == null || !inventory.Has("item.raw_food")) return false;
            inventory.Remove("item.raw_food");
            return inventory.Add("food.cooked");
        }
    }
}
