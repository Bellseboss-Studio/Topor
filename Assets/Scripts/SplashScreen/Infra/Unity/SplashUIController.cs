using System.Collections;
using System.Collections.Generic;
using Game.Splash.Domain.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Splash.Infra.Unity
{
    public class SplashUIController : MonoBehaviour
    {
        [SerializeField] private Image splashImage;
        [SerializeField] private List<Sprite> listOfSprites;

        public IEnumerator PlaySequence(List<SplashItem> sequence, System.Action onFinished)
        {
            foreach (var item in sequence)
            {
                switch (item.Type)
                {
                    case SplashType.Image:
                        yield return StartCoroutine(ShowImage(item.ResourcePath, item.Duration));
                        break;

                    case SplashType.Video:
                        yield return StartCoroutine(PlayVideo(item.ResourcePath));
                        break;
                }
            }

            onFinished?.Invoke();
        }

        private IEnumerator ShowImage(string path, float duration)
        {
            var image = listOfSprites.Find(s => s.name == path);
            splashImage.gameObject.SetActive(true);
            splashImage.sprite = image;
            yield return new WaitForSeconds(duration);
        }

        private IEnumerator PlayVideo(string path)
        {
            splashImage.gameObject.SetActive(false);
            yield return null;
        }

        public void StopAll()
        {
        }
    }
}