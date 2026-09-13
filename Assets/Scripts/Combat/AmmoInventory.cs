using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Combat
{
    public class AmmoInventory : MonoBehaviour
    {
        [SerializeField] private string ammoItemId = "ammo.basic";

        public int Count(InventorySystem inventory)
        {
            return inventory == null ? 0 : inventory.CountItem(ammoItemId);
        }

        public bool Consume(InventorySystem inventory, int amount = 1)
        {
            if (inventory == null || amount <= 0 || Count(inventory) < amount) return false;
            for (int i = 0; i < amount; i++) inventory.Remove(ammoItemId);
            return true;
        }
    }
}
