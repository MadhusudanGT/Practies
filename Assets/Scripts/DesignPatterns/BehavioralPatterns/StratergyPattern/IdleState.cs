using UnityEngine;

public class IdleState : PlayerBase
{
    private MoveStates currentStateName;
    public MoveStates Name { get => currentStateName; set => currentStateName = value; }

    Player _player;

    public IdleState(Player player, MoveStates currentState)
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
            _player?.SetNewState(new WalkState(_player, MoveStates.Walk));
        }
    }

    public void Update()
    {
        
    }
}
