using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Crafting
{
    public class MedicineCraftingSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;

        public bool CraftBandage()
        {
            return Craft("item.cloth", 1, "item.herb", 1, "medicine.bandage");
        }

        public bool CraftFirstAidKit()
        {
            return Craft("item.bandage", 2, "item.medicine.alcohol", 1, "medicine.first_aid_kit");
        }

        public bool CraftHerbalTonic()
        {
            return Craft("item.herb", 2, "item.clean_water", 1, "medicine.herbal_tonic");
        }

        private bool Craft(string ingredientA, int amountA, string ingredientB, int amountB, string result)
        {
            if (inventory == null) return false;
            if (inventory.CountItem(ingredientA) < amountA || inventory.CountItem(ingredientB) < amountB)
                return false;

            for (int i = 0; i < amountA; i++) inventory.Remove(ingredientA);
            for (int i = 0; i < amountB; i++) inventory.Remove(ingredientB);

            if (inventory.Add(result)) return true;

            for (int i = 0; i < amountA; i++) inventory.Add(ingredientA);
            for (int i = 0; i < amountB; i++) inventory.Add(ingredientB);
            return false;
        }
    }
}
