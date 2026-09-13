using UnityEngine;

namespace FMAI.Survival.InputSystem
{
    public class MobileActionInput : MonoBehaviour
    {
        private Combat.Weapon weapon;

        private void Awake()
        {
            weapon = GetComponentInChildren<Combat.Weapon>();
        }

        public void Fire()
        {
            if (weapon == null) weapon = GetComponentInChildren<Combat.Weapon>();
            weapon?.TryFire();
        }
    }
}
