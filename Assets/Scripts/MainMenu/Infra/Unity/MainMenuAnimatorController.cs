using UnityEngine;

namespace Game.MainMenu.Infra.Unity
{
    [RequireComponent(typeof(Animator))]
    public class MainMenuAnimatorController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayIntro()
        {
            _animator.Play("Intro");
        }

        public void PlayIdle()
        {
            _animator.Play("Idle");
        }
    }
}