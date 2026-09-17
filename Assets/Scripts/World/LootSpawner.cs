using UnityEngine;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.World
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private ItemData[] lootTable;
        [SerializeField] private Transform spawnPoint;

        public ItemData RollLoot()
        {
            if (lootTable == null || lootTable.Length == 0) return null;
            return lootTable[Random.Range(0, lootTable.Length)];
        }

        public ItemData SpawnLoot()
        {
            // Prototype-safe data roll; physical pickup spawning will be added with Pickup.
            return RollLoot();
        }
    }
}
