using System;
using System.Collections.Generic;
using Game.Splash.Domain.Entities;

namespace Game.Splash.Domain.Interfaces
{
    public interface ISplashService
    {
        void PlaySequence(List<SplashItem> sequence);
        void Skip();
        event Action OnSplashStarted;
        event Action OnSplashEnded;
    }
}