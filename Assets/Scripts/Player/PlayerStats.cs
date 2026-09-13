using UnityEngine;

namespace FMAI.Survival.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float maxHunger = 100f;
        [SerializeField] private float hungerDrainPerMinute = 2f;

        public float Health { get; private set; }
        public float Hunger { get; private set; }
        public float MaxHealth => maxHealth;
        public float MaxHunger => maxHunger;

        private void Awake()
        {
            Health = maxHealth;
            Hunger = maxHunger;
        }

        private void Update()
        {
            Hunger = Mathf.Max(0f, Hunger - hungerDrainPerMinute / 60f * Time.deltaTime);
            if (Hunger <= 0f)
                TakeDamage(2f * Time.deltaTime);
        }

        public void Eat(float amount)
        {
            Hunger = Mathf.Clamp(Hunger + amount, 0f, maxHunger);
        }

        public void RestoreHealth(float amount)
        {
            if (amount <= 0f || IsDead) return;
            Health = Mathf.Clamp(Health + amount, 0f, maxHealth);
        }

        public void TakeDamage(float amount)
        {
            Health = Mathf.Clamp(Health - amount, 0f, maxHealth);
        }

        public bool IsDead => Health <= 0f;
    }
}
