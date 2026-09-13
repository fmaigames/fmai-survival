using FMAI.Survival.Combat;
using UnityEngine;

namespace FMAI.Survival.Bootstrap
{
    public class PrototypeCombatSpawner : MonoBehaviour
    {
        [SerializeField] private Camera aimCamera;

        private void Start()
        {
            if (aimCamera == null) aimCamera = Camera.main;
            if (aimCamera == null) return;

            GameObject weaponObject = new GameObject("Prototype_Weapon");
            weaponObject.transform.SetParent(transform, false);
            Weapon weapon = weaponObject.AddComponent<Weapon>();

            var field = typeof(Weapon).GetField("aimCamera", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field?.SetValue(weapon, aimCamera);
        }
    }
}
