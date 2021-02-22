using System;
using Player.FPS;
using Player.RTS;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private RTSPlayerController rtsPlayerController;
        [SerializeField]
        private FPSPlayerController fpsPlayerController;

        private bool rtsMode = true;
        private void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame)
            {
                if (rtsMode)
                {
                    rtsMode = false;
                    rtsPlayerController.gameObject.SetActive(rtsMode);
                    fpsPlayerController.gameObject.SetActive(!rtsMode);
                }
                else
                {
                    rtsMode = true;
                    rtsPlayerController.gameObject.SetActive(rtsMode);
                    fpsPlayerController.gameObject.SetActive(!rtsMode);
                }
            }
        }
    }
}