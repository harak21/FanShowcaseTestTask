using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace FanShowcase.Core.Scene
{
    public class SelectableButton : SelectableObject
    {
        private Subject<bool> _onButtonClicked;
        
        [SerializeField] private Renderer currentRenderer;
        [SerializeField] private Color selectedColor = Color.red;
        [SerializeField] private Vector3 startRotation;
        [SerializeField] private Vector3 endRotation;
        [SerializeField] private float rotationDuration = 0.2f;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickSound;

        private bool _state;
        private bool _isChangingState;

        private void Awake()
        {
            currentRenderer.material.SetColor("_EmissionColor", selectedColor);
            _onButtonClicked ??= new Subject<bool>();
        }

        public IObservable<bool> SelectableButtonAsObservable()
        {
            return _onButtonClicked ??= new Subject<bool>();
        }

        protected override void OnPointerEnter()
        {
            currentRenderer.material.EnableKeyword("_EMISSION");
        }

        protected override void OnPointerExit()
        {
            currentRenderer.material.DisableKeyword("_EMISSION");
        }

        protected override void OnPointerClick()
        {
            if (_isChangingState)
                return;
            
            _state = !_state;
            _onButtonClicked.OnNext(_state);
            audioSource.PlayOneShot(clickSound);

            Observable.FromCoroutine(Rotate).Subscribe();
        }

        private IEnumerator Rotate()
        {
            _isChangingState = true;
            var startQuaternion = transform.rotation;
            var endQuaternion = Quaternion.Euler(_state ? endRotation : startRotation);
            var localTime = 0f;
            
            while (localTime < rotationDuration)
            {
                transform.rotation = Quaternion.Lerp(startQuaternion, endQuaternion, localTime/rotationDuration);
                localTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = endQuaternion;
            _isChangingState = false;
        }
    }
}