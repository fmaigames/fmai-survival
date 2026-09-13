using UnityEngine;
using FMAI.Survival.Player;
using FMAI.Survival.Inventory;
using FMAI.Survival.Enemies;

namespace FMAI.Survival.AI
{
    public class InGameAIHelper : MonoBehaviour
    {
        [SerializeField] private float lowHealthThreshold = 30f;
        [SerializeField] private float lowHungerThreshold = 25f;
        [SerializeField] private float threatRange = 18f;

        private PlayerStats player;
        private InventorySystem inventory;

        private void Awake()
        {
            player = GetComponent<PlayerStats>();
            inventory = GetComponent<InventorySystem>();
        }

        public string GetHint()
        {
            if (player == null) return "AI Help: Player system not ready.";
            if (player.IsDead) return "AI Help: You are down. Restore health before continuing.";
            if (player.Health <= lowHealthThreshold) return "AI Help: Health is low. Use medicine or food and avoid combat.";
            if (player.Hunger <= lowHungerThreshold) return "AI Help: Hunger is low. Eat food before exploring further.";

            EnemyAI threat = FindNearestThreat();
            if (threat != null) return "AI Help: Enemy nearby. Keep distance or engage when ready.";
            if (inventory != null && inventory.Count == 0) return "AI Help: Explore nearby containers and collect basic resources.";
            return "AI Help: Area looks stable. Explore, loot, craft, and complete your next mission.";
        }

        public EnemyAI FindNearestThreat()
        {
            EnemyAI nearest = null;
            float best = threatRange * threatRange;
            foreach (EnemyAI enemy in FindObjectsByType<EnemyAI>(FindObjectsSortMode.None))
            {
                if (enemy == null) continue;
                float distance = (enemy.transform.position - transform.position).sqrMagnitude;
                if (distance < best)
                {
                    best = distance;
                    nearest = enemy;
                }
            }
            return nearest;
        }
    }
}
