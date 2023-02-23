using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        //_gameplayState.GetComponent<Text>().text = "STATE: Game Play";
        _controller.Gameplay();
        Debug.Log("STATE: Game Play");
        //_gameplayState.GetComponent<Text>().text = "Listen for Player Inputs";
        _controller.PlayerInputs();
        Debug.Log("Listen for Player Inputs");
        //_gameplayState.GetComponent<Text>().text = "Display Player HUD";
        _controller.PlayerHUD();
        Debug.Log("Display Player HUD");
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

        // check for win condition
        if(_controller.Touch.IsTapPressed == true)
        {
            Debug.Log("You Win!");
            //_controller.WinFeedback();
            SceneManager.LoadScene("Win");
            // Win State, reload level, change back to SetupState, etc.
        }
        // check for lose condition
        else if(StateDuration >= _controller.TapLimitDuration)
        {
            Debug.Log("You Lose!");
            //_controller.LoseFeedback();
            SceneManager.LoadScene("Lose");
            // Lose State, reload level, change back to SetupState, etc.
        }
    }
}
