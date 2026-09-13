using UnityEngine;
using FMAI.Survival.Enemies;

namespace FMAI.Survival.Combat
{
    public enum HeavyWeaponType
    {
        BombLauncher,
        RocketLauncher,
        PlasmaCannon
    }

    public class HeavyWeaponSystem : MonoBehaviour
    {
        [SerializeField] private float explosionRadius = 4f;
        [SerializeField] private float damage = 80f;
        [SerializeField] private float cooldown = 3f;
        private float nextFireTime;

        public bool Fire(HeavyWeaponType weaponType, Vector3 impactPoint)
        {
            if (Time.time < nextFireTime) return false;

            float multiplier = weaponType switch
            {
                HeavyWeaponType.BombLauncher => 1f,
                HeavyWeaponType.RocketLauncher => 1.25f,
                HeavyWeaponType.PlasmaCannon => 1.5f,
                _ => 1f
            };

            Collider[] hits = Physics.OverlapSphere(impactPoint, explosionRadius);
            foreach (Collider hit in hits)
            {
                EnemyAI enemy = hit.GetComponentInParent<EnemyAI>();
                if (enemy != null) enemy.TakeDamage(damage * multiplier);
            }

            nextFireTime = Time.time + cooldown;
            return true;
        }
    }
}
