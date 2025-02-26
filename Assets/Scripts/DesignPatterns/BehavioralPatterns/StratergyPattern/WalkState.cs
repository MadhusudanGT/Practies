using UnityEngine;

public class WalkState : PlayerBase
{
    private MoveStates currentStateName;
    public MoveStates Name { get => currentStateName; set => currentStateName = value; }

    Player _player;
    public WalkState(Player player, MoveStates currentState)
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
            _player?.SetNewState(new RunningState(_player, MoveStates.Running));
        }
    }

    public void Update()
    {
       
    }
}
