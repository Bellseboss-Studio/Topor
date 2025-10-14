namespace Game.Splash.Domain.Entities
{
    public enum SplashType
    {
        Image,
        Video
    }

    public class SplashItem
    {
        public SplashType Type { get; }
        public string ResourcePath { get; }
        public float Duration { get; }

        public SplashItem(SplashType type, string resourcePath, float duration)
        {
            Type = type;
            ResourcePath = resourcePath;
            Duration = duration;
        }
    }
}