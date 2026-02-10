using UnityEngine;

namespace Game.MainMenu.Infra.Unity
{
    [RequireComponent(typeof(Animator))]
    public class MainMenuAnimatorController : MonoBehaviour
    {
        private static readonly int Intro = Animator.StringToHash("Intro");
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            if (_animator == null)
            {
                Debug.LogError("Animator component not found on " + gameObject.name);
            }
        }

        public void PlayIntro()
        {
            if (_animator != null)
            {
                _animator.SetBool(Intro, true);
            }
        }

        public void PlayIdle()
        {
            if (_animator != null)
            {
                _animator.SetBool(Intro, false);
            }
        }
    }
}