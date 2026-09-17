using UnityEngine;

namespace FMAI.Survival.Player
{
    public class MobileInputBridge : MonoBehaviour
    {
        public Vector2 Move { get; private set; }
        public Vector2 Look { get; private set; }

        private int moveFingerId = -1;
        private int lookFingerId = -1;
        private Vector2 moveStart;
        private Vector2 lookStart;
        [SerializeField] private float moveRadius = 160f;
        [SerializeField] private float lookSensitivity = 0.015f;

        private void Update()
        {
            Move = Vector2.zero;
            Look = Vector2.zero;

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                bool leftSide = touch.position.x < Screen.width * 0.5f;

                if (touch.phase == TouchPhase.Began)
                {
                    if (leftSide && moveFingerId < 0)
                    {
                        moveFingerId = touch.fingerId;
                        moveStart = touch.position;
                    }
                    else if (!leftSide && lookFingerId < 0)
                    {
                        lookFingerId = touch.fingerId;
                        lookStart = touch.position;
                    }
                }

                if (touch.fingerId == moveFingerId)
                {
                    Move = Vector2.ClampMagnitude((touch.position - moveStart) / moveRadius, 1f);
                    if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                        moveFingerId = -1;
                }
                else if (touch.fingerId == lookFingerId)
                {
                    Look = (touch.position - lookStart) * lookSensitivity;
                    lookStart = touch.position;
                    if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                        lookFingerId = -1;
                }
            }
        }
    }
}
