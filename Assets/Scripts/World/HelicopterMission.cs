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
            player.SetPositionAndRotation(destination.position, destination.rotation);
            activated = false;
            return true;
        }
    }
}