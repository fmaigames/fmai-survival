using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Combat
{
    public class WeaponCraftingSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;

        public bool CraftBasicPistol()
        {
            if (inventory == null) return false;
            return Craft("weapon.pistol", "item.scrap", 5, "item.wood", 2);
        }

        public bool CraftPipeMelee()
        {
            if (inventory == null) return false;
            return Craft("weapon.pipe", "item.scrap", 3, "item.wood", 2);
        }

        public bool CraftBasicRifle()
        {
            if (inventory == null) return false;
            return Craft("weapon.rifle", "item.scrap", 10, "item.wood", 4);
        }

        private bool Craft(string resultId, string materialA, int amountA, string materialB, int amountB)
        {
            if (inventory.Has(resultId)) return false;
            if (inventory.CountItem(materialA) < amountA || inventory.CountItem(materialB) < amountB)
                return false;

            for (int i = 0; i < amountA; i++) inventory.Remove(materialA);
            for (int i = 0; i < amountB; i++) inventory.Remove(materialB);

            if (inventory.Add(resultId)) return true;

            for (int i = 0; i < amountA; i++) inventory.Add(materialA);
            for (int i = 0; i < amountB; i++) inventory.Add(materialB);
            return false;
        }
    }
}
