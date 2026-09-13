using System.Collections.Generic;
using FMAI.Survival.Inventory;
using FMAI.Survival.Player;
using UnityEngine;

namespace FMAI.Survival.Cooking
{
    public class CookingSystem : MonoBehaviour
    {
        [System.Serializable]
        public class Recipe
        {
            public string ingredient;
            public string result = "food.cooked";
            public float hungerRestore = 25f;
        }

        [SerializeField] private List<Recipe> recipes = new();

        public bool Cook(int recipeIndex, InventorySystem inventory, PlayerStats player)
        {
            if (inventory == null || player == null || recipeIndex < 0 || recipeIndex >= recipes.Count)
                return false;

            Recipe recipe = recipes[recipeIndex];
            if (!inventory.Remove(recipe.ingredient)) return false;

            player.Eat(recipe.hungerRestore);
            inventory.Add(recipe.result);
            return true;
        }
    }
}
