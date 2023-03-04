using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    [SerializeField] Text _gamestartState;

    // this is our constructor, called when this state is created
    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class varaiables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        _controller.GameplayState();
        Debug.Log("STATE: Game Setup");
        //_gamestartState.GetComponent<Text>().text = "STATE: Game Setup";
        _controller.LoadSave();
        Debug.Log("Load Save Data");
        //_gamestartState.GetComponent<Text>().text = "Load Save Data";
        _controller.SpawnUnits();
        Debug.Log("Spawn Units");
        //_gamestartState.GetComponent<Text>().text = "Spawn Units";

        //_controller.UnitSpawner.Spawn(_controller.PlayerUnitPrefab,
            //_controller.PlayerUnitSpawnLocation);
           
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        _stateMachine.ChangeState(_stateMachine.PlayState);
    }
}
