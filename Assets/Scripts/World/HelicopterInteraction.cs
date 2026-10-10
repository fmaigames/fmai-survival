using UnityEngine;

namespace FMAI.Survival.World
{
    public class HelicopterInteraction : MonoBehaviour
    {
        [SerializeField] private float interactionRadius = 3f;
        [SerializeField] private bool missionReady;

        private bool extracted;

        public bool IsExtracted => extracted;

        public bool CanExtract(Vector3 playerPosition)
        {
            Vector3 offset = playerPosition - transform.position;
            offset.y = 0f;

            return !extracted &&
                   missionReady &&
                   offset.sqrMagnitude <=
                   interactionRadius * interactionRadius;
        }

        public bool TryCompleteExtraction()
        {
            if (extracted || !missionReady)
                return false;

            extracted = true;
            return true;
        }

        public void SetMissionReady(bool ready)
        {
            missionReady = ready;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(
                transform.position,
                interactionRadius
            );
        }
    }
}