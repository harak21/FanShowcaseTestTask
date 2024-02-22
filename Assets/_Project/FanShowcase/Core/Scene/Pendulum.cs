using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;

namespace FanShowcase.Core.Scene
{
    public class Pendulum : MonoBehaviour
    {
        [SerializeField] private SelectableButton swayButton;
        [SerializeField] private SelectableButton enableButton;
        [SerializeField] private float angle;
        [SerializeField] private float speed;

        private bool _isRotated;
        private bool _isSwaying;
        private float _currentState;
        private float _currentTime = 0.5f;
        private IDisposable _swayDisposable;

        private void Start()
        {
            swayButton.SelectableButtonAsObservable().Subscribe(ChangeSwayingState);
            enableButton.SelectableButtonAsObservable().Subscribe(ChangeRotationState);
        }

        private void ChangeRotationState(bool state)
        {
            _isRotated = state;
            CheckConditions();
        }

        private void ChangeSwayingState(bool state)
        {
            _isSwaying = state;
            CheckConditions();
        }

        private void CheckConditions()
        {
            if (!_isSwaying || !_isRotated)
            {
                _swayDisposable?.Dispose();
            }
            else
            {
                _swayDisposable = Observable.FromCoroutine(Sway).Subscribe();
            }
        }

        private IEnumerator Sway(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _currentTime += Time.deltaTime * speed;
                _currentState = Mathf.PingPong(_currentTime, 1);
                var currentAngle = Mathf.Lerp(-angle, angle, _currentState);
                transform.rotation = Quaternion.Euler(new Vector3(0, currentAngle, 0));
                yield return null;
            }
        }
    }
}