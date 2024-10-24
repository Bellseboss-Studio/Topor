public class ShowUiToHowToPlayState : BaseState
{
    public ShowUiToHowToPlayState()
    {
        _metaDataState = new MetaDataState()
        {
            id = "ShowUiToHowToPlay",
            isFirst = false,
            nextStateId = "ShowHowToPlay"
        };
    }
}