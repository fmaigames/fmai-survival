using FMAI.Survival;
using UnityEngine;

namespace FMAI.Survival.Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 60f;
        [SerializeField] private float detectionRange = 12f;
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float moveSpeed = 2.5f;
        [SerializeField] private float damage = 10f;
        [SerializeField] private float attackCooldown = 1.25f;

        private float health;
        private float nextAttackTime;
        private Transform target;

        private void Awake()
        {
            health = maxHealth;
        }

        private void Update()
        {
            if (health <= 0f) return;

            if (target == null)
            {
                var player = FindFirstObjectByType<PlayerStats>();
                if (player == null) return;
                target = player.transform;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > detectionRange) return;

            Vector3 direction = target.position - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(direction),
                    6f * Time.deltaTime);
            }

            if (distance > attackRange)
            {
                transform.position += direction.normalized * moveSpeed * Time.deltaTime;
                return;
            }

            if (Time.time < nextAttackTime) return;

            var stats = target.GetComponent<PlayerStats>();
            if (stats != null)
                stats.ApplyDamage(damage);

            nextAttackTime = Time.time + attackCooldown;
        }

        public void TakeDamage(float amount)
        {
            if (amount <= 0f || health <= 0f) return;

            health = Mathf.Max(0f, health - amount);
            if (health <= 0f)
                Destroy(gameObject);
        }
    }
}
