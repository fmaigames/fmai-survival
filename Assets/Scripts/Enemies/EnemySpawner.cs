using UnityEngine;

namespace FMAI.Survival.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int initialCount = 3;

        public void SpawnInitialEnemies()
        {
            if (enemyPrefab == null || spawnPoints == null || spawnPoints.Length == 0) return;

            int count = Mathf.Max(0, initialCount);
            for (int i = 0; i < count; i++)
            {
                Transform point = spawnPoints[i % spawnPoints.Length];
                Instantiate(enemyPrefab, point.position, point.rotation);
            }
        }

        private void Start()
        {
            SpawnInitialEnemies();
        }
    }
}
