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