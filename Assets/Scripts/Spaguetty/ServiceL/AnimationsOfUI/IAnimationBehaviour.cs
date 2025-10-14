public interface IAnimationBehaviour
{
    void PlaySuccessHit();
    void PlayFailHit();
    void PlayPositiveFeedback();
    void PlayNegativeFeedback();
    void PlayVictory();
    void PlayDefeat();
    void PlayIdle();
    void PlayHammer();
}