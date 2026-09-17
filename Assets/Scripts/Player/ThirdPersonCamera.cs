using UnityEngine;

namespace FMAI.Survival.Player
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float distance = 5f;
        [SerializeField] private float height = 2f;
        [SerializeField] private float followSpeed = 10f;
        [SerializeField] private float rotationSpeed = 120f;
        [SerializeField] private float minPitch = -25f;
        [SerializeField] private float maxPitch = 55f;

        private float yaw;
        private float pitch = 15f;

        public void SetTarget(Transform cameraTarget)
        {
            target = cameraTarget;
        }

        private void LateUpdate()
        {
            if (target == null) return;

            float lookX = Input.GetAxis("Mouse X");
            float lookY = Input.GetAxis("Mouse Y");
            yaw += lookX * rotationSpeed * Time.deltaTime;
            pitch = Mathf.Clamp(pitch - lookY * rotationSpeed * Time.deltaTime, minPitch, maxPitch);

            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
            Vector3 desiredPosition = target.position + Vector3.up * height - rotation * Vector3.forward * distance;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
