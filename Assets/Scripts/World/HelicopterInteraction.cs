using UnityEngine;

namespace FMAI.Survival.World
{
    public class HelicopterInteraction : MonoBehaviour
    {
        [SerializeField] private float interactionRadius = 3f;
        [SerializeField] private bool missionReady;
        private bool extracted;

        public bool CanExtract(Vector3 playerPosition)
        {
            Vector3 offset = playerPosition - transform.position;
            offset.y = 0f;
            return !extracted && missionReady && offset.sqrMagnitude <= interactionRadius * interactionRadius;
        }

        public bool TryExtract(Vector3 playerPosition)
        {
            if (!CanExtract(playerPosition)) return false;
            extracted = true;
            return true;
        }

        public void SetMissionReady(bool ready) => missionReady = ready;

        public bool IsExtracted => extracted;

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }
}
