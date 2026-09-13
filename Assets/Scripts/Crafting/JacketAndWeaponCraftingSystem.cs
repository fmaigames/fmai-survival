using UnityEngine;
using FMAI.Survival.Inventory;
using FMAI.Survival.Combat;

namespace FMAI.Survival.Crafting
{
    public class JacketAndWeaponCraftingSystem : MonoBehaviour
    {
        [SerializeField] private InventorySystem inventory;
        [SerializeField] private ArmorSystem armor;

        public bool CraftLightProtectiveJacket()
        {
            return CraftJacket("armor.jacket.light", 8, 4, 2, 0.20f, 60f);
        }

        public bool CraftTacticalJacket()
        {
            return CraftJacket("armor.jacket.tactical", 12, 6, 3, 0.30f, 90f);
        }

        public bool CraftHeavyBulletResistantJacket()
        {
            return CraftJacket("armor.jacket.heavy", 18, 10, 5, 0.40f, 120f);
        }

        private bool CraftJacket(string resultId, int scrap, int cloth, int fiber, float reduction, float durability)
        {
            if (inventory == null || armor == null) return false;
            if (inventory.Has(resultId)) return false;
            if (inventory.CountItem("item.scrap") < scrap ||
                inventory.CountItem("item.cloth") < cloth ||
                inventory.CountItem("item.fiber") < fiber)
                return false;

            Remove("item.scrap", scrap);
            Remove("item.cloth", cloth);
            Remove("item.fiber", fiber);

            if (!inventory.Add(resultId))
            {
                Restore("item.scrap", scrap);
                Restore("item.cloth", cloth);
                Restore("item.fiber", fiber);
                return false;
            }

            armor.Equip(durability, reduction);
            return true;
        }

        public bool CraftWeapon(string weaponId)
        {
            if (inventory == null) return false;

            switch (weaponId)
            {
                case "weapon.pistol":
                    return Craft("weapon.pistol", "item.scrap", 5, "item.wood", 2);
                case "weapon.pipe":
                    return Craft("weapon.pipe", "item.scrap", 3, "item.wood", 2);
                case "weapon.rifle":
                    return Craft("weapon.rifle", "item.scrap", 10, "item.wood", 4);
                default:
                    return false;
            }
        }

        private bool Craft(string resultId, string materialA, int amountA, string materialB, int amountB)
        {
            if (inventory.Has(resultId)) return false;
            if (inventory.CountItem(materialA) < amountA || inventory.CountItem(materialB) < amountB)
                return false;

            Remove(materialA, amountA);
            Remove(materialB, amountB);

            if (inventory.Add(resultId)) return true;

            Restore(materialA, amountA);
            Restore(materialB, amountB);
            return false;
        }

        private void Remove(string itemId, int amount)
        {
            for (int i = 0; i < amount; i++) inventory.Remove(itemId);
        }

        private void Restore(string itemId, int amount)
        {
            for (int i = 0; i < amount; i++) inventory.Add(itemId);
        }
    }
}
