using System;
using System.Collections;
using System.Collections.Generic;
using Game.Splash.Domain.Entities;
using Game.Splash.Domain.Interfaces;
using UnityEngine;

namespace Game.Splash.Infra.Unity
{
    public class SplashService : MonoBehaviour, ISplashService
    {
        [SerializeField] private SplashUIController uiController;
        [SerializeField] private SplashInputHandler inputHandler;

        private Coroutine sequenceRoutine;
        private bool isPlaying;

        public event Action OnSplashStarted;
        public event Action OnSplashEnded;

        public void PlaySequence(List<SplashItem> sequence)
        {
            if (isPlaying) return;
            sequenceRoutine = StartCoroutine(PlayRoutine(sequence));
        }

        private IEnumerator PlayRoutine(List<SplashItem> sequence)
        {
            isPlaying = true;
            OnSplashStarted?.Invoke();

            inputHandler.OnSkip += Skip;

            yield return uiController.PlaySequence(sequence, EndSequence);
        }

        public void Skip()
        {
            if (!isPlaying) return;
            StopCoroutine(sequenceRoutine);
            uiController.StopAll();
            EndSequence();
        }

        private void EndSequence()
        {
            inputHandler.OnSkip -= Skip;
            isPlaying = false;
            OnSplashEnded?.Invoke();
        }
    }
}