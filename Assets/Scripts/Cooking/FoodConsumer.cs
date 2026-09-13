using FMAI.Survival.Inventory;
using FMAI.Survival.Items;
using FMAI.Survival;
using UnityEngine;

namespace FMAI.Survival.Cooking
{
    public class FoodConsumer : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private FoodItem food;

        public bool Consume()
        {
            if (inventory == null) inventory = GetComponent<InventorySystem>();
            if (playerStats == null) playerStats = GetComponent<PlayerStats>();
            if (inventory == null || playerStats == null || food == null) return false;
            if (!inventory.Has(food.ItemId)) return false;

            playerStats.Eat(food.HungerRestored);
            return inventory.Remove(food.ItemId);
        }
    }
}
