using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.Events;

namespace EMA.Scripts.InputEma
{
    public class HoldAndReleaseInput : MonoSingleton<HoldAndReleaseInput>
    {
        [Header("Touch Delta")]
        private UnityEvent<Vector2> holdEvent = new UnityEvent<Vector2>();
        private UnityEvent<Vector2> releaseEvent = new UnityEvent<Vector2>();
        private UnityEvent touchStartedEvent = new UnityEvent();

        private Vector2 _startTouch;
        private Vector2 _swipeDelta;

        private bool _executeRelease;
        private bool _touching;
        private bool _startTouchEventChecker;

        #region Props

        public UnityEvent TouchStartedEvent => touchStartedEvent;

        public UnityEvent<Vector2> HoldEvent => holdEvent;

        public UnityEvent<Vector2> ReleaseEvent => releaseEvent;

        #endregion

        private void Update()
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    _startTouch = touch.position;
                    _swipeDelta = Vector2.zero;
                    _touching = true;
                    _startTouchEventChecker = true;
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    _swipeDelta = touch.position - _startTouch;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _executeRelease = true;
                    _touching = false;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_startTouchEventChecker)
            {
                _startTouchEventChecker = false;
                touchStartedEvent.Invoke();
            }
            if (_touching)
            {
                holdEvent?.Invoke(_swipeDelta);
            }

            else
            {
                if (_executeRelease)
                {
                    _executeRelease = false;
                    releaseEvent?.Invoke(_swipeDelta);
                }
            }
        }
    }
}