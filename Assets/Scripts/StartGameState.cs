public class StartGameState : BaseState
{
    public StartGameState(TouchTopo touchTopo)
    {
        _metaDataState = new MetaDataState()
        {
            id = "StartGame",
            isFirst = true,
            nextStateId = "ReadyToPlay"
        };

        _teaTime.Pause().Add(() =>
        {
            touchTopo.CanPlaySounds(false);
            ServiceLocator.Instance.GetService<IUiControllerService>().ShowAnimationStart();
        }).Wait(() => ServiceLocator.Instance.GetService<IUiControllerService>().AnimationStartGame).Add(() =>
        {
            ServiceLocator.Instance.GetService<IUiControllerService>().ShowStartPanel();
        });

    }
}