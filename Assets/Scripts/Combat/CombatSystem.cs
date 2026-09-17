using UnityEngine;
using FMAI.Survival.Enemies;

namespace FMAI.Survival.Combat
{
    public class CombatSystem : MonoBehaviour
    {
        [SerializeField] private float attackRange = 3f;
        [SerializeField] private float damage = 20f;
        [SerializeField] private LayerMask enemyMask;

        public bool Attack()
        {
            Vector3 origin = transform.position + Vector3.up;
            Collider[] hits = Physics.OverlapSphere(origin, attackRange, enemyMask);
            bool hit = false;

            foreach (Collider collider in hits)
            {
                EnemyAI enemy = collider.GetComponentInParent<EnemyAI>();
                if (enemy == null) continue;
                enemy.TakeDamage(damage);
                hit = true;
            }

            return hit;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position + Vector3.up, attackRange);
        }
    }
}
