using FMAI.Survival.Enemies;
using UnityEngine;

namespace FMAI.Survival.Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float range = 20f;
        [SerializeField] private float fireCooldown = 0.35f;
        [SerializeField] private Camera aimCamera;
        private float nextFireTime;

        public bool TryFire()
        {
            if (Time.time < nextFireTime || aimCamera == null) return false;
            nextFireTime = Time.time + fireCooldown;
            Ray ray = aimCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                var enemy = hit.collider.GetComponentInParent<EnemyAI>();
                if (enemy != null) enemy.TakeDamage(damage);
            }
            return true;
        }
    }
}
