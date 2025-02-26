using UnityEngine;

public abstract class PlayerState
{
    public abstract void OnPlayerStateChanged(PlayerController state);
    public abstract void OnEnterState(PlayerController state, MoveStates currentState);
    public abstract MoveStates CurrentPlayerState { get; set; }
}
