using System.Collections.Generic;
using Game.Splash.Domain.Entities;
using Game.Splash.Domain.Interfaces;

namespace Game.Splash.Domain.UseCases
{
    public class PlaySplashSequenceUseCase
    {
        private readonly ISplashService _splashService;

        public PlaySplashSequenceUseCase(ISplashService splashService)
        {
            _splashService = splashService;
        }

        public void Execute(List<SplashItem> sequence)
        {
            _splashService.PlaySequence(sequence);
        }
    }
}