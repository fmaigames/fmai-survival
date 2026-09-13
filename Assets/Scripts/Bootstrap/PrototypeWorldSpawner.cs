using UnityEngine;
using FMAI.Survival.Enemies;
using FMAI.Survival.Inventory;

namespace FMAI.Survival.Bootstrap
{
    public class PrototypeWorldSpawner : MonoBehaviour
    {
        [SerializeField] private int lootCount = 8;
        [SerializeField] private int enemyCount = 3;

        private void Start()
        {
            SpawnLoot();
            SpawnEnemies();
        }

        private void SpawnLoot()
        {
            for (int i = 0; i < lootCount; i++)
            {
                GameObject item = GameObject.CreatePrimitive(PrimitiveType.Cube);
                item.name = $"Loot_{i + 1}";
                item.transform.position = new Vector3(
                    Random.Range(-14f, 14f),
                    0.35f,
                    Random.Range(-14f, 14f));
                item.transform.localScale = Vector3.one * 0.7f;

                Pickup pickup = item.AddComponent<Pickup>();
                pickup.itemId = i % 2 == 0 ? "wood" : "scrap";
                pickup.quantity = 1;
            }
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                enemy.name = $"Enemy_{i + 1}";
                enemy.transform.position = new Vector3(
                    Random.Range(-12f, 12f),
                    1f,
                    Random.Range(6f, 16f));

                enemy.AddComponent<EnemyAI>();
            }
        }
    }
}
