using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FanShowcase.Input
{
    [UsedImplicitly]
    public class PlayerInputSystem : IInputSystem
    {
        public event Action<float> OnZoomPerformed;
        public event Action OnLookStarted;
        public event Action OnLookEnded;
        public Vector2 LookValue => _pointerDelta.ReadValue<Vector2>();

        private readonly InputAction _pointerDelta;
        
        public PlayerInputSystem()
        {
            var playerInput = new PlayerInput();
            playerInput.Enable();

            _pointerDelta = playerInput.Default.PointerDelta;
            playerInput.Default.Look.started += LookOnStarted;
            playerInput.Default.Look.performed += LookOnPerformed;
            playerInput.Default.Zoom.performed += ZoomOnPerformed;
        }

        private void ZoomOnPerformed(InputAction.CallbackContext context)
        {
            OnZoomPerformed?.Invoke(context.ReadValue<Vector2>().y);
        }

        private void LookOnStarted(InputAction.CallbackContext context)
        {
            OnLookStarted?.Invoke();
        }
        
        private void LookOnPerformed(InputAction.CallbackContext context)
        {
            OnLookEnded?.Invoke();
        }
    }
}