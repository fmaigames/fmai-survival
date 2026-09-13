using UnityEngine;

namespace FMAI.Survival
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float maxHunger = 100f;
        [SerializeField] private float hungerDecayPerSecond = 0.5f;
        [SerializeField] private float starvationDamagePerSecond = 2f;

        public float Health { get; private set; }
        public float Hunger { get; private set; }
        public bool IsDead => Health <= 0f;

        private void Awake()
        {
            Health = maxHealth;
            Hunger = maxHunger;
        }

        private void Update()
        {
            if (IsDead) return;
            Hunger = Mathf.Max(0f, Hunger - hungerDecayPerSecond * Time.deltaTime);
            if (Hunger <= 0f) ApplyDamage(starvationDamagePerSecond * Time.deltaTime);
        }

        public void ApplyDamage(float amount)
        {
            if (amount <= 0f || IsDead) return;
            Health = Mathf.Max(0f, Health - amount);
        }

        public void Eat(float hungerRestored)
        {
            if (hungerRestored <= 0f || IsDead) return;
            Hunger = Mathf.Min(maxHunger, Hunger + hungerRestored);
        }

        public void RestoreHealth(float amount)
        {
            if (amount <= 0f || IsDead) return;
            Health = Mathf.Min(maxHealth, Health + amount);
        }
    }
}
