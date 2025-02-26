using UnityEngine;

public class WalkStateP : PlayerState
{
    private MoveStates _currentMovingState;
    public override MoveStates CurrentPlayerState { get => _currentMovingState; set => _currentMovingState = value; }
    public override void OnEnterState(PlayerController state, MoveStates currentMovingState)
    {
        CurrentPlayerState = currentMovingState;
        Debug.Log($"State Changes {CurrentPlayerState} State");
    }

    public override void OnPlayerStateChanged(PlayerController state)
    {
        if (Input.GetKeyDown(KeyCode.P)) state.SetNewState(new JumpingState(), MoveStates.Jump);
    }
}
