using System;

namespace Game.Domain.Interfaces
{
    public interface ITransitionService
    {
        void IniciarCarga(int escenaObjetivo, float delayAntesDeCarga = 0f);
        void OcultarCortinilla();

        event Action OnCargaIniciada;
        event Action OnCargaFinalizada;
        event Action<int> OnEscenaLista;
    }
}