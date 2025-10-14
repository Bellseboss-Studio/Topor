using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Game.Splash.Infra.Unity
{
    public class SplashInputHandler : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnSkip;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnSkip?.Invoke();
        }

        private void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
                OnSkip?.Invoke();
#elif UNITY_ANDROID || UNITY_IOS
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
                OnSkip?.Invoke();
#endif
        }
    }
}