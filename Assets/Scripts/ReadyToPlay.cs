public class ReadyToPlay : BaseState
{
    public ReadyToPlay(TouchTopo touchTopo)
    {
        _metaDataState = new MetaDataState()
        {
            id = "ReadyToPlay",
            isFirst = true,
            nextStateId = "GameState"
        };
        _teaTime.Pause().Add(() => { touchTopo.CanPlaySounds(false); }).Wait(() =>
            ServiceLocator.Instance.GetService<IUiControllerService>().SelectedStartGame).Add(() =>
        {
        });
    }
}