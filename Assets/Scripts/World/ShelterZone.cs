using UnityEngine;

namespace FMAI.Survival.World
{
    public class ShelterZone : MonoBehaviour
    {
        [SerializeField] private float shelterRadius = 4f;
        [SerializeField] private bool blockEnemies = true;

        public bool IsInside(Vector3 position)
        {
            Vector3 offset = position - transform.position;
            offset.y = 0f;
            return offset.sqrMagnitude <= shelterRadius * shelterRadius;
        }

        public bool BlocksEnemies => blockEnemies;

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, shelterRadius);
        }
    }
}
