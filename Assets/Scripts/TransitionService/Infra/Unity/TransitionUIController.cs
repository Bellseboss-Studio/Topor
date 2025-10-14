using System.Collections;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Infrastructure.Unity
{
    public class TransitionUIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup cortinilla;
        [SerializeField] private Slider barraCarga;
        [SerializeField] private TextMeshProUGUI textoPorcentaje;

        public IEnumerator FadeIn(float duration = 0.5f)
        {
            cortinilla.blocksRaycasts = true;
            cortinilla.interactable = true;
            // yield return cortinilla.DOFade(1f, duration).SetEase(Ease.InOutQuad).WaitForCompletion();
            yield return StartCoroutine(FadeCanvasGroup(cortinilla, 0f, 1f, 0.5f));
        }

        private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
        {
            float time = 0f;
            while (time < duration)
            {
                cg.alpha = Mathf.Lerp(start, end, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            cg.alpha = end;
        }

        public IEnumerator FadeOut(float duration = 0.5f)
        {
            // yield return cortinilla.DOFade(0f, duration).WaitForCompletion();
            yield return StartCoroutine(FadeCanvasGroup(cortinilla, 1f, 0f, duration));
            cortinilla.blocksRaycasts = false;
            cortinilla.interactable = false;
        }

        public void UpdateProgress(float progress)
        {
            barraCarga.value = progress;
            if (textoPorcentaje != null)
                textoPorcentaje.text = $"{(int)(progress * 100)}%";
        }

        public void ResetUI()
        {
            cortinilla.alpha = 0f;
            cortinilla.blocksRaycasts = false;
            cortinilla.interactable = false;
            barraCarga.value = barraCarga.minValue;
            if (textoPorcentaje != null)
                textoPorcentaje.text = "0%";
        }
    }
}