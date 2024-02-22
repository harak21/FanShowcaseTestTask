using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;

namespace FanShowcase.Core.Scene
{
    public class Rotor : MonoBehaviour
    {
        [SerializeField] private SelectableButton button;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float accelerationTime = 0.3f;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float maxVolume = 0.5f;

        private bool _state;
        private float _currentRotationSpeed;
        private float _currentAccelerationTime;
        private IDisposable _rotationChangeDisposable;

        private void Start()
        {
            button.SelectableButtonAsObservable().Subscribe(ChangeState);
            Observable
                .FromCoroutine(Rotate)
                .Subscribe();
            _currentAccelerationTime = accelerationTime;
            audioSource.Play();
        }

        private void ChangeState(bool state)
        {
            _state = state;
            _rotationChangeDisposable?.Dispose();
            _rotationChangeDisposable = 
                Observable
                    .FromCoroutine(ChangeRotationSpeed)
                    .Subscribe();
        }

        private IEnumerator ChangeRotationSpeed(CancellationToken token)
        {
            var targetSpeed = _state ? rotationSpeed : 0f;
            var cashedTime = accelerationTime - _currentAccelerationTime;
            var cashedSpeed = _currentRotationSpeed;
            
            var targetVolume = _state ? maxVolume : 0f;
            var cashedVolume = audioSource.volume;
            

            while (cashedTime < accelerationTime && !token.IsCancellationRequested)
            {
                cashedTime += Time.deltaTime;
                _currentAccelerationTime = cashedTime;
                _currentRotationSpeed =
                    Mathf.Lerp(cashedSpeed, targetSpeed, _currentAccelerationTime / accelerationTime);
                audioSource.volume =
                    Mathf.SmoothStep(cashedVolume, targetVolume, _currentAccelerationTime / accelerationTime);
                yield return null;
            }

            if (token.IsCancellationRequested)
            {
                yield break;
            }

            _currentAccelerationTime = accelerationTime;
            _currentRotationSpeed = targetSpeed;
        }

        private IEnumerator Rotate(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                yield return null;
                transform.Rotate(Vector3.forward, _currentRotationSpeed, Space.Self);
            }
        }
    }
}