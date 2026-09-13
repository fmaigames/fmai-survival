using UnityEngine;

namespace FMAI.Survival.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4.5f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float gravity = -20f;
        [SerializeField] private Transform cameraTransform;

        private CharacterController controller;
        private Vector3 verticalVelocity;

        public void InitializeCamera(Transform cameraTarget)
        {
            cameraTransform = cameraTarget;
        }

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (cameraTransform == null && Camera.main != null)
                cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            input = Vector2.ClampMagnitude(input, 1f);

            Vector3 forward = cameraTransform != null ? cameraTransform.forward : Vector3.forward;
            Vector3 right = cameraTransform != null ? cameraTransform.right : Vector3.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 move = forward * input.y + right * input.x;
            controller.Move(move * moveSpeed * Time.deltaTime);

            if (move.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            if (controller.isGrounded && verticalVelocity.y < 0f)
                verticalVelocity.y = -2f;

            verticalVelocity.y += gravity * Time.deltaTime;
            controller.Move(verticalVelocity * Time.deltaTime);
        }
    }
}
