namespace SelectorLevel.Domain.UseCase
{
    public interface IScrollSoundUseCase
    {
        bool ShouldPlay(float velocity);
        void Reset();
    }
}