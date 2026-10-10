using UnityEngine;

namespace FMAI.Survival.World
{
    public class HelicopterMission : MonoBehaviour
    {
        [SerializeField] private string missionId = "mission.signal";
        [SerializeField] private Transform destination;
        private bool activated;

        public string MissionId => missionId;
        public bool Activated => activated;

        public void SetDestination(Transform target)
        {
            destination = target;
        }

        public void Activate()
        {
            activated = true;
        }

        public bool TryLaunch(Transform player)
        {
            if (!activated || player == null || destination == null) return false;

            // Disable CharacterController during teleport to avoid stale collision state.
            CharacterController controller = player.GetComponent<CharacterController>();
            bool controllerWasEnabled = controller != null && controller.enabled;

            if (controller != null)
                controller.enabled = false;

            player.SetPositionAndRotation(destination.position, destination.rotation);

            if (controller != null)
                controller.enabled = controllerWasEnabled;

            activated = false;
            return true;
        }
    }
}