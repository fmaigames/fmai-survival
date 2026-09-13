using UnityEngine;
using FMAI.Survival.Enemies;

namespace FMAI.Survival.Combat
{
    public class AutoFireController : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private Camera aimCamera;
        [SerializeField] private float targetRange = 20f;
        [SerializeField] private bool enabledOnStart = true;
        private bool active;

        private void Awake()
        {
            active = enabledOnStart;
            if (weapon == null) weapon = GetComponentInChildren<Weapon>();
            if (aimCamera == null) aimCamera = Camera.main;
        }

        private void Update()
        {
            if (!active || weapon == null || aimCamera == null) return;
            EnemyAI target = FindNearestEnemy();
            if (target == null) return;

            Vector3 direction = target.transform.position - aimCamera.transform.position;
            if (direction.sqrMagnitude > 0.01f)
                aimCamera.transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);

            weapon.TryFire();
        }

        private EnemyAI FindNearestEnemy()
        {
            EnemyAI nearest = null;
            float bestDistance = targetRange * targetRange;
            EnemyAI[] enemies = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None);
            foreach (EnemyAI enemy in enemies)
            {
                if (enemy == null) continue;
                float distance = (enemy.transform.position - transform.position).sqrMagnitude;
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    nearest = enemy;
                }
            }
            return nearest;
        }

        public void SetAutoFire(bool value) => active = value;
        public bool IsAutoFireEnabled => active;
    }
}
