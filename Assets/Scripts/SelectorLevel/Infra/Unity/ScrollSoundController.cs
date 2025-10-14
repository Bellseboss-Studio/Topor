using System;
using SelectorLevel.Domain.GateWay;
using SelectorLevel.Domain.UseCase;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SelectorLevel.Infra.Unity
{
    [RequireComponent(typeof(ScrollRect))]
    public class ScrollSoundController : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField, Range(0f, 1f)] private float minVelocityThreshold = 0.1f;
        [SerializeField] private float maxVelocity = 5000f;
        [SerializeField] private UnityEvent onScrollSound;
        [SerializeField] private string scrollSoundId = "ui_scroll";

        private IAudioService _audioService;

        private IScrollSoundUseCase _logic;
        private bool _isScrolling;


        public void Configure()
        {
            _logic = new ScrollSoundLogic(minVelocityThreshold, maxVelocity);
        }


        private void Update()
        {
            if (!_isScrolling) return;

            var currentVelocity = Mathf.Abs(scrollRect.velocity.x);
            if (_logic.ShouldPlay(currentVelocity))
            {
                onScrollSound?.Invoke();
            }
        }

        public void OnScrollStart()
        {
            _isScrolling = true;
        }

        public void OnScrollEnd()
        {
            _isScrolling = false;
            _logic.Reset();
        }
    }
}