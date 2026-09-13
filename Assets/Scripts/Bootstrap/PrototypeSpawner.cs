using FMAI.Survival.Enemies;
using FMAI.Survival.World;
using UnityEngine;

namespace FMAI.Survival.Bootstrap
{
    public class PrototypeSpawner : MonoBehaviour
    {
        [SerializeField] private int enemyCount = 3;
        [SerializeField] private int lootCount = 8;
        [SerializeField] private float spawnRadius = 12f;

        private static readonly string[] LootIds =
        {
            "resource.wood",
            "resource.scrap",
            "food.basic",
            "resource.herb"
        };

        private void Start()
        {
            SpawnEnemies();
            SpawnLoot();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 position = RandomPoint(7f, spawnRadius);
                GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                enemy.name = $"Prototype_Enemy_{i + 1}";
                enemy.transform.position = position + Vector3.up;
                enemy.AddComponent<EnemyAI>();
            }
        }

        private void SpawnLoot()
        {
            for (int i = 0; i < lootCount; i++)
            {
                Vector3 position = RandomPoint(3f, spawnRadius);
                GameObject loot = GameObject.CreatePrimitive(PrimitiveType.Cube);
                loot.name = $"Prototype_Loot_{i + 1}";
                loot.transform.position = position + Vector3.up * 0.35f;
                loot.transform.localScale = Vector3.one * 0.5f;

                Collider collider = loot.GetComponent<Collider>();
                collider.isTrigger = true;
                Pickup pickup = loot.AddComponent<Pickup>();
                var field = typeof(Pickup).GetField("itemId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                field?.SetValue(pickup, LootIds[i % LootIds.Length]);
            }
        }

        private Vector3 RandomPoint(float minRadius, float maxRadius)
        {
            Vector2 point = Random.insideUnitCircle.normalized * Random.Range(minRadius, maxRadius);
            return new Vector3(point.x, 0f, point.y);
        }
    }
}
