using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.RTS
{
    public class RTSCameraController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform = null;

        [SerializeField] private float cameraMoveSpeed = 1.0f;
        [SerializeField] private float cameraSprintSpeed = 2.0f;
        [SerializeField] private float cameraZoomSpeed = 1.0f;

        private PlayerActions playerActions;
        private bool sprinting = false;

        private void Start()
        {
            playerActions = new PlayerActions();
            playerActions.Enable();
            playerActions.PlayerControls.CameraSprint.performed += (InputAction.CallbackContext context) =>
            {
                sprinting = true;
            };
            playerActions.PlayerControls.CameraSprint.canceled += (InputAction.CallbackContext context) =>
            {
                sprinting = false;
            };

            cameraTransform.LookAt(transform);
        }

        private void LateUpdate()
        {
            // Detect movement
            Vector2 value = playerActions.PlayerControls.CameraMove.ReadValue<Vector2>();
            if (value.sqrMagnitude > 0)
            {
                float speed = Time.deltaTime * (!sprinting ? cameraMoveSpeed : cameraSprintSpeed);

                Vector3 translation = new Vector3(-value.x, 0, -value.y);
                transform.Translate(translation * speed);
            }

            // Detect zooming
            float scroll = playerActions.PlayerControls.CameraZoom.ReadValue<float>();
            if (scroll * scroll > 0)
            {
                Vector3 zoom = new Vector3(0, 0, scroll * cameraZoomSpeed * Time.deltaTime);
                cameraTransform.Translate(zoom);
            }
        }
    }
}