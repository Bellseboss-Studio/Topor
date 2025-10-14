using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorLevelController : MonoBehaviour, ISelectorLevelController
{
    [SerializeField] List<LevelController> levels;
    [SerializeField] private float timeToSplash;
    [SerializeField] private string videoClipStart;
    [SerializeField] private GameObject video;
    [SerializeField] private Button skipButton;

    private void Awake()
    {
        ServiceLocator.Instance.RegisterService<ISelectorLevelController>(this);
    }

    private void Start()
    {
        video.SetActive(true);
        StartCoroutine(FinishVideo(timeToSplash));
        skipButton.onClick.AddListener(() =>
        {
            video.SetActive(false);
        });
    }

    private IEnumerator FinishVideo(float f)
    {
        yield return new WaitForSeconds(f);
        video.SetActive(false);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<ISelectorLevelController>();
    }
}