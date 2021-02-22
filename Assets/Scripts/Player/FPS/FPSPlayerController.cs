using System;
using Input;
using UnityEngine;

namespace Player.FPS
{
    public class FPSPlayerController : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        [SerializeField] private CharacterController characterController;

        [SerializeField] private float walkingSpeed = 7.5f;
        [SerializeField] private float runningSpeed = 11.5f;
        [SerializeField] private float jumpSpeed = 8.0f;
        [SerializeField] private float gravity = 20.0f;
        [SerializeField] private float lookSpeed = 2.0f;
        [SerializeField] private float lookXLimit = 45.0f;

        private Vector3 moveDirection = Vector3.zero;
        private float rotationX = 0;
        private bool canMove = true;
        private bool sprinting = false;
        private PlayerActions actions;

        private void Start()
        {
            actions = new PlayerActions();
            actions.FPS.Sprint.performed += context => sprinting = true;
            actions.FPS.Sprint.canceled += context => sprinting = false;
            actions.Enable();

            
        }

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleRotation()
        {
            if (canMove)
            {
                rotationX += -actions.FPS.LookY.ReadValue<float>() * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

                transform.rotation *= Quaternion.Euler(0, actions.FPS.LookX.ReadValue<float>() * lookSpeed, 0);
            }
        }

        private void HandleMovement()
        {
            Vector2 movementInput = actions.FPS.Movement.ReadValue<Vector2>();

            Transform tform = transform;
            Vector2 movementSpeed = canMove ? (sprinting ? runningSpeed : walkingSpeed) * movementInput : Vector2.zero;

            float movementDirectionY = moveDirection.y;
            moveDirection = (tform.forward * movementSpeed.y) + (tform.right * movementSpeed.x);

            if (actions.FPS.Jump.triggered && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
            
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}