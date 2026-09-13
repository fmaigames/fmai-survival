using UnityEngine;

namespace FMAI.Survival.InputSystem
{
    public class PrototypeTouchUI : MonoBehaviour
    {
        [SerializeField] private MobileActionInput actionInput;

        public void FirePressed()
        {
            actionInput?.Fire();
        }
    }
}
