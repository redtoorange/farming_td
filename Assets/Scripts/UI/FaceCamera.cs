using UnityEngine;

namespace UI
{
    public class FaceCamera : MonoBehaviour
    {
        private Camera camera;

        private void Start()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            Quaternion cameraRotation = camera.transform.rotation;
            transform.LookAt(
                transform.position + cameraRotation * Vector3.forward,
                cameraRotation * Vector3.up
            );
        }
    }
}