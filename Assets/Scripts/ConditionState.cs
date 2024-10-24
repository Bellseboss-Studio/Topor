using UnityEngine.SceneManagement;

public class ConditionState : BaseState
{
    public ConditionState(TouchTopo touchTopo, FruitsMono fruitsMono, int nextScene)
    {
        _metaDataState = new MetaDataState()
        {
            id = "Condition",
            isFirst = false,
            nextStateId = "End"
        };
        _teaTime.Pause().Add(() =>
        {
            
        }).Wait(() =>
            ServiceLocator.Instance.GetService<ITimeLineService>().GameIsEnded || fruitsMono.AllFruitAreDead).Add(() =>
        {
            touchTopo.CanPlaySounds(false);
        }).Add(() =>
        {
            if (fruitsMono.AllFruitAreDead)
            {
                ServiceLocator.Instance.GetService<IUiControllerService>().SetTitleEndGame("You Lose!");
                ServiceLocator.Instance.GetService<IUiControllerService>().SetSubtitleEndGame("All Fruits are Dead!");
            }
            else
            {
                ServiceLocator.Instance.GetService<IUiControllerService>().SetTitleEndGame("You Win!");
                ServiceLocator.Instance.GetService<IUiControllerService>().SetSubtitleEndGame("You save a few fruits!");
            }

            ServiceLocator.Instance.GetService<ITimeLineService>().StopGame();
            ServiceLocator.Instance.GetService<IUiControllerService>().ShowEndGamePanel(true);
        }).Wait(() => ServiceLocator.Instance.GetService<IUiControllerService>().SelectedEndGame).Add(() =>
        {
            ServiceLocator.Instance.GetService<IUiControllerService>().HideEndGamePanel();
            ServiceLocator.Instance.GetService<IUiControllerService>().ShowEndGameAnimation(fruitsMono.AllFruitAreDead);
        }).Wait(() => ServiceLocator.Instance.GetService<IUiControllerService>().AnimationStartGame).Add(() =>
        {
            SceneManager.LoadScene(nextScene + 1);
        });
    }
}