using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VideoPlayerScreen : MonoBehaviour
{
    public UnityEvent OnFinishVideo;
    [SerializeField] private float timeToSplash;
    [SerializeField] private string videoClipStart;
    
    private void Start()
    {
        StartCoroutine(FinishVideo(timeToSplash));
    }

    private IEnumerator FinishVideo(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        OnFinishVideo.Invoke();
    }
}