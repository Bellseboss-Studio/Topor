using System;
using UnityEngine;

public class GameLoopWithTutorial : MonoBehaviour
{
    [SerializeField] private TouchTopo touchTopo;
    [SerializeField] private FruitsMono fruitsMono;

    private void Start()
    {
        //Create States to Tutorial
        StateMachinePattern stateMachinePattern = new StateMachinePattern();

        stateMachinePattern.AddState(new StartGameState(touchTopo));
        stateMachinePattern.AddState(new ReadyToPlay(touchTopo));
        stateMachinePattern.AddState(new GameState(touchTopo, fruitsMono));
        stateMachinePattern.AddState(new ConditionState(touchTopo, fruitsMono, 1));
        stateMachinePattern.AddState(new ShowUiToHowToPlayState());

        // Start Game
        // Show Step 1 (Mecanica de Wakamole)
        // Show Step 2 (Mecanica de Tiempo)
        // Show Step 3 (Mecanica de Monedas)
    }
}