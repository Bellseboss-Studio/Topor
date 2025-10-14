using SelectorLevel.Domain.Entities;

namespace SelectorLevel.Domain.UseCase
{
    public interface ISelectorLevelUseCase
    {
        void SaveLevel(SelectorLevelDTO dto);
    }
}