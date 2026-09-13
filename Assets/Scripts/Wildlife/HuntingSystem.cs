using System;
using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Wildlife
{
    public enum WildlifeType
    {
        Deer,
        Boar,
        Rabbit,
        Wolf,
        Fox,
        Bear
    }

    public class HuntingSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;

        public bool Hunt(WildlifeType animal)
        {
            if (inventory == null) return false;

            string meatId = "food.raw_meat";
            int meat = animal switch
            {
                WildlifeType.Rabbit => 1,
                WildlifeType.Fox => 2,
                WildlifeType.Deer => 4,
                WildlifeType.Boar => 5,
                WildlifeType.Wolf => 3,
                WildlifeType.Bear => 7,
                _ => 1
            };

            if (!inventory.Add(meatId)) return false;
            if (animal == WildlifeType.Deer || animal == WildlifeType.Boar || animal == WildlifeType.Bear)
                inventory.Add("item.hide");
            if (animal == WildlifeType.Wolf || animal == WildlifeType.Fox)
                inventory.Add("item.fur");

            return true;
        }
    }
}
