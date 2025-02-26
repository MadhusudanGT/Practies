using UnityEngine;

public class JumpingState : PlayerState
{
    private MoveStates currentMovingState;
    public override MoveStates CurrentPlayerState { get => currentMovingState; set => currentMovingState = value; }

    public override void OnEnterState(PlayerController state, MoveStates currentMovingState)
    {
        CurrentPlayerState = currentMovingState;
        Debug.Log($"State Changes {CurrentPlayerState} State");
    }

    public override void OnPlayerStateChanged(PlayerController state)
    {
        if (!state.IsGrounded()) state.SetNewState(new IdleStateP(), MoveStates.Idle);
    }
}
