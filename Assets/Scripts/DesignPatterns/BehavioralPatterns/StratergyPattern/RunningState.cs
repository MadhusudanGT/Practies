using UnityEngine;

public class RunningState : PlayerBase
{
    private MoveStates currentStateName;
    public MoveStates Name { get => currentStateName; set => currentStateName = value; }

    Player _player;

    public RunningState(Player player, MoveStates currentState)
    {
        Name = currentState;
        _player = player;
        Debug.Log($"Init {currentStateName} State Constructor");
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Handle Input {currentStateName} State");
            _player?.SetNewState(new IdleState(_player, MoveStates.Idle));
        }
    }

    public void Update()
    {
       
    }
}
