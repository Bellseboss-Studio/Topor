namespace SelectorLevel.Domain.UseCase
{
    public class ScrollSoundLogic : IScrollSoundUseCase
    {
        private readonly float _minVelocityThreshold;
        private readonly float _maxVelocity;
        private bool _canPlay;

        public ScrollSoundLogic(float minVelocityThreshold, float maxVelocity)
        {
            _minVelocityThreshold = minVelocityThreshold;
            _maxVelocity = maxVelocity;
            _canPlay = true;
        }

        public bool ShouldPlay(float velocity)
        {
            float normalized = UnityEngine.Mathf.Clamp(velocity / _maxVelocity, 0, 1);

            if (normalized > _minVelocityThreshold && _canPlay)
            {
                _canPlay = false;
                return true;
            }

            if (normalized == 0)
                _canPlay = true;

            return false;
        }

        public void Reset()
        {
            _canPlay = true;
        }
    }
}