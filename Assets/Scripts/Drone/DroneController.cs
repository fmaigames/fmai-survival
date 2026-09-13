using UnityEngine;

namespace FMAI.Survival.Drone
{
    public enum DroneRole
    {
        Player,
        Medical,
        Combat
    }

    public class DroneController : MonoBehaviour
    {
        [SerializeField] private DroneRole role = DroneRole.Player;
        [SerializeField] private Transform followTarget;
        [SerializeField] private float followDistance = 4f;
        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private float hoverHeight = 2f;

        public DroneRole Role => role;

        private void Update()
        {
            if (followTarget == null) return;

            Vector3 desired = followTarget.position
                - followTarget.forward * followDistance
                + Vector3.up * hoverHeight;

            transform.position = Vector3.MoveTowards(transform.position, desired, moveSpeed * Time.deltaTime);
            Vector3 look = followTarget.position - transform.position;
            if (look.sqrMagnitude > 0.01f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look), Time.deltaTime * 5f);
        }

        public void SetFollowTarget(Transform target)
        {
            followTarget = target;
        }
    }
}
