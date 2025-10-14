using System;

namespace Game.TransitionService.Bootstrap
{
    public interface ITransitionServiceBoostrap
    {
        void IniciarCarga(int escenaObjetivo, float delayAntesDeCarga = 0f);
        void OcultarCortinilla();

        event Action OnCargaIniciada;
        event Action OnCargaFinalizada;
        event Action<int> OnEscenaLista;
    }
}