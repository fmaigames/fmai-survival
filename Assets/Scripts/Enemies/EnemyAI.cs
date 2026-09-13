using FMAI.Survival.Player;
using UnityEngine;

namespace FMAI.Survival.Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 60f;
        [SerializeField] private float detectionRange = 12f;
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float damage = 10f;
        [SerializeField] private float attackCooldown = 1.25f;
        private float health;
        private float nextAttackTime;
        private Transform target;

        private void Awake() => health = maxHealth;

        private void Update()
        {
            if (health <= 0f) return;
            if (target == null)
            {
                var player = FindFirstObjectByType<PlayerStats>();
                if (player != null) target = player.transform;
                else return;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > detectionRange) return;

            Vector3 look = target.position - transform.position;
            look.y = 0f;
            if (look.sqrMagnitude > 0.01f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look), 6f * Time.deltaTime);

            if (distance <= attackRange && Time.time >= nextAttackTime)
            {
                var stats = target.GetComponent<PlayerStats>();
                if (stats != null) stats.TakeDamage(damage);
                nextAttackTime = Time.time + attackCooldown;
            }
        }

        public void TakeDamage(float amount)
        {
            health = Mathf.Max(0f, health - amount);
            if (health <= 0f) Destroy(gameObject);
        }
    }
}
