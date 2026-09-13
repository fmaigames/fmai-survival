using UnityEngine;
using FMAI.Survival.Inventory;
using FMAI.Survival.Player;

namespace FMAI.Survival.Items
{
    public class MedicineItem : MonoBehaviour
    {
        [SerializeField] private string itemId = "medicine.bandage";
        [SerializeField] private float healAmount = 25f;

        public bool Use(PlayerStats player, InventorySystem inventory)
        {
            if (player == null || inventory == null || !inventory.Has(itemId)) return false;
            if (!inventory.Remove(itemId)) return false;

            player.Heal(healAmount);
            return true;
        }
    }
}
