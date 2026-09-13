using FMAI.Survival.Enemies;
using UnityEngine;

namespace FMAI.Survival.Combat
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange = 2.5f;
        [SerializeField] private float damage = 25f;
        [SerializeField] private float attackCooldown = 0.75f;
        [SerializeField] private LayerMask enemyLayers = ~0;

        private float nextAttackTime;

        public bool TryAttack()
        {
            if (Time.time < nextAttackTime) return false;
            nextAttackTime = Time.time + attackCooldown;

            Collider[] hits = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);
            EnemyAI nearest = null;
            float nearestDistance = float.MaxValue;

            foreach (Collider hit in hits)
            {
                EnemyAI enemy = hit.GetComponentInParent<EnemyAI>();
                if (enemy == null) continue;

                float distance = (enemy.transform.position - transform.position).sqrMagnitude;
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearest = enemy;
                }
            }

            if (nearest == null) return false;
            nearest.TakeDamage(damage);
            return true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}
