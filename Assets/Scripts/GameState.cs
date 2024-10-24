public class GameState : BaseState
{
    public GameState(TouchTopo touchTopo, FruitsMono fruitsMono)
    {
        _metaDataState = new MetaDataState()
        {
            id = "GameState",
            isFirst = false,
            nextStateId = "Condition"
        };
        _teaTime.Pause().Add(() =>
            {
                touchTopo.CanPlaySounds(true);
                ServiceLocator.Instance.GetService<IUiControllerService>().HideStartPanel();
                fruitsMono.StartToSpawn();
            }).Wait(() => fruitsMono.Finished)
            .Add(() => { ServiceLocator.Instance.GetService<ITimeLineService>().Configure(); }).Add(() =>
            {
                ServiceLocator.Instance.GetService<ITimeLineService>().StartCount();
            });
    }
}