using System.Collections.Generic;
using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Combat
{
    public class EnemyDropTable : MonoBehaviour
    {
        [System.Serializable]
        public class Drop
        {
            public string itemId;
            [Range(0f, 1f)] public float chance = 0.5f;
        }

        [SerializeField] private List<Drop> drops = new();
        [SerializeField] private InventorySystem targetInventory;

        public void GrantDrops()
        {
            if (targetInventory == null) return;
            foreach (Drop drop in drops)
            {
                if (drop != null && !string.IsNullOrWhiteSpace(drop.itemId) && Random.value <= drop.chance)
                    targetInventory.Add(drop.itemId);
            }
        }
    }
}
