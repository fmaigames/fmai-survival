using FMAI.Survival.Inventory;
using UnityEngine;

namespace FMAI.Survival.Crafting
{
    public class CraftingSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;
        [SerializeField] private string woodItemId = "item.wood";
        [SerializeField] private int woodRequired = 3;
        [SerializeField] private string shelterKitId = "item.shelter_kit";

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

        public bool CraftShelterKit()
        {
            if (inventory == null || inventory.CountItem(woodItemId) < woodRequired)
                return false;

            for (int i = 0; i < woodRequired; i++)
                inventory.Remove(woodItemId);

            return inventory.Add(shelterKitId);
        }
    }
}
