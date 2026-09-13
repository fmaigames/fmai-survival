using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Base
{
    public class DecorationCraftingSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;

        public bool CraftChair() => Craft("decor.chair", "item.wood", 4, "item.scrap", 1);
        public bool CraftTable() => Craft("decor.table", "item.wood", 6, "item.scrap", 2);
        public bool CraftStorageShelf() => Craft("decor.shelf", "item.wood", 5, "item.scrap", 2);
        public bool CraftBed() => Craft("decor.bed", "item.wood", 6, "item.cloth", 4);
        public bool CraftLamp() => Craft("decor.lamp", "item.scrap", 3, "item.glass", 2);
        public bool CraftWallArt() => Craft("decor.wall_art", "item.wood", 2, "item.cloth", 2);
        public bool CraftGardenPlanter() => Craft("decor.planter", "item.wood", 3, "item.herb", 1);

        private bool Craft(string resultId, string materialA, int amountA, string materialB, int amountB)
        {
            if (inventory == null || inventory.Has(resultId)) return false;
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
