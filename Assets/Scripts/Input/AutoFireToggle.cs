using UnityEngine;
using FMAI.Survival.Combat;

namespace FMAI.Survival.InputSystem
{
    public class AutoFireToggle : MonoBehaviour
    {
        [SerializeField] private AutoFireController controller;

        public void Toggle()
        {
            if (controller != null)
                controller.SetAutoFire(!controller.IsAutoFireEnabled);
        }
    }
}
