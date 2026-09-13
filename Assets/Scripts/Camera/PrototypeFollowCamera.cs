using UnityEngine;

namespace FMAI.Survival.CameraSystem
{
    public class PrototypeFollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0f, 5.5f, -7.5f);
        [SerializeField] private float followSpeed = 8f;
        [SerializeField] private float lookHeight = 1.2f;

        public void SetTarget(Transform value) => target = value;

        private void LateUpdate()
        {
            if (target == null) return;

            Vector3 desired = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desired, followSpeed * Time.deltaTime);
            Vector3 lookPoint = target.position + Vector3.up * lookHeight;
            transform.LookAt(lookPoint);
        }
    }
}
