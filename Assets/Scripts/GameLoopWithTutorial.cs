using System;
using System.Collections;
using UnityEngine;

public class GameLoopWithTutorial : MonoBehaviour
{
    [SerializeField] private TouchTopo touchTopo;
    [SerializeField] private FruitsMono fruitsMono;
    private StateMachinePattern _stateMachinePattern;

    private void Start()
    {
        //Create States to Tutorial
        _stateMachinePattern = new StateMachinePattern();

        _stateMachinePattern.AddState(new StartGameState(touchTopo));
        _stateMachinePattern.AddState(new ReadyToPlay(touchTopo));
        _stateMachinePattern.AddState(new GameState(touchTopo, fruitsMono));
        _stateMachinePattern.AddState(new ConditionState(touchTopo, fruitsMono, 1));
        _stateMachinePattern.AddState(new ShowUiToHowToPlayState());

        // Start Game
        // Show Step 1 (Mecanica de Wakamole)
        // Show Step 2 (Mecanica de Tiempo)
        // Show Step 3 (Mecanica de Monedas)
        _stateMachinePattern.Configure();
        StartCoroutine(StateMachine());
    }

    private IEnumerator StateMachine()
    {
        var currentState = _stateMachinePattern.GetState();
        while (currentState is not null)
        {
            currentState.OnEnterState();
            //yield return null;
            //validate if teatime is finished with a boolean var
            Debug.Assert(currentState != null, nameof(currentState) + " != null");
            while (currentState.IsCompleted())
            {
                yield return null;
            }
            currentState.OnExitState();
            currentState = _stateMachinePattern.GetState(_stateMachinePattern.GetNextState());
        }

        Debug.Log("State Finished");
    }
}