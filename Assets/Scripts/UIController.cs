using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class UIController : MonoBehaviour, IUiControllerService
{
    [SerializeField] private GameObject startPanel, endGamePanel, animationPanel, uiOfGame;
    [SerializeField] private Button startButton, endButton;
    [SerializeField] private TextMeshProUGUI titleEndGame, subtitleEndGame;
    [SerializeField] private float timeToWatch;
    [SerializeField] private GameObject video;
    [SerializeField] private Button skipButton;

    [Tooltip("Nombres de los videos")] [SerializeField]
    private string videoClipStart, videoClipEndLose, videoClipEndWin;

    [Header("FMOD events for videos")] [SerializeField]
    private FMODUnity.StudioEventEmitter m_EventEmitter;

    [SerializeField] private FMODUnity.EventReference m_EventNameStart, m_EventNameEndLoose, m_EventNameEndWin;

    private IGameLoop _gameLoop;
    public bool SelectedEndGame { get; private set; }
    public bool SelectedStartGame { get; private set; }
    public bool AnimationStartGame { get; private set; }

    private void Awake()
    {
        ServiceLocator.Instance.RegisterService<IUiControllerService>(this);
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.UnregisterService<IUiControllerService>();
    }

    public void Configure(IGameLoop gameLoop)
    {
        _gameLoop = gameLoop;
        SelectedEndGame = false;
        SelectedStartGame = false;

        startButton.onClick.AddListener(() => { SelectedStartGame = true; });

        endButton.onClick.AddListener(() => { SelectedEndGame = true; });
        startPanel.SetActive(false);
        endGamePanel.SetActive(false);
        uiOfGame.SetActive(false);
        animationPanel.SetActive(false);

        skipButton.onClick.AddListener(FinishVideo);
    }

    public void SetTitleEndGame(string title)
    {
        titleEndGame.text = title;
    }

    public void SetSubtitleEndGame(string subtitle)
    {
        subtitleEndGame.text = subtitle;
    }

    public void ShowAnimationStart()
    {
        animationPanel.SetActive(true);
        startPanel.SetActive(false);
        endGamePanel.SetActive(false);
        uiOfGame.SetActive(false);
        AssignFMODEvent(m_EventNameStart);
        video.SetActive(true);
        StartCoroutine(StartVideo(timeToWatch));
    }

    private void AssignFMODEvent(FMODUnity.EventReference eventRef)
    {
        m_EventEmitter.EventReference = eventRef;
    }

    public void ShowUiOfGame()
    {
        animationPanel.SetActive(false);
        endGamePanel.SetActive(false);
        startPanel.SetActive(false);
        uiOfGame.SetActive(true);
    }

    public void ShowStartPanel()
    {
        animationPanel.SetActive(false);
        endGamePanel.SetActive(false);
        uiOfGame.SetActive(false);
        startPanel.SetActive(true);
    }

    private IEnumerator StartVideo(float timeToWait)
    {
        StartVideoPlayer();
        StartAudioForVideo();
        yield return new WaitForSeconds(timeToWait);
        FinishVideo();
    }

    private void StartAudioForVideo()
    {
        m_EventEmitter.Play();
    }

    private void StartVideoPlayer()
    {
        AnimationStartGame = false;
    }

    private void FinishVideo()
    {
        AnimationStartGame = true;
    }

    public void HideStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void ShowEndGamePanel(bool winOrLose)
    {
        endGamePanel.SetActive(true);
        startPanel.SetActive(false);
        animationPanel.SetActive(false);
        uiOfGame.SetActive(false);
    }

    public void HideEndGamePanel()
    {
        endGamePanel.SetActive(false);
    }

    public void ShowEndGameAnimation(bool lose)
    {
        AnimationStartGame = false;
        animationPanel.SetActive(true);
        startPanel.SetActive(false);
        endGamePanel.SetActive(false);
        uiOfGame.SetActive(false);
        AssignFMODEvent(lose ? m_EventNameEndLoose : m_EventNameEndWin);
        video.SetActive(true);
        StartCoroutine(StartVideo(timeToWatch));
    }
}

public interface IUiControllerService
{
    void ShowStartPanel();
    bool SelectedStartGame { get; }
    bool SelectedEndGame { get; }
    bool AnimationStartGame { get; }
    void HideStartPanel();
    void ShowEndGamePanel(bool b);
    void HideEndGamePanel();
    void ShowEndGameAnimation(bool lose);
    void Configure(IGameLoop gameLoop);
    void SetTitleEndGame(string title);
    void SetSubtitleEndGame(string subtitle);
    void ShowAnimationStart();
    void ShowUiOfGame();
}