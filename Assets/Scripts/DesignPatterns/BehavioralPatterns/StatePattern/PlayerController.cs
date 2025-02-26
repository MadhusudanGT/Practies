using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerState _currentState;

    private void Start()
    {
        SetNewState(new IdleStateP(),MoveStates.Idle);
    }

    public void SetNewState(PlayerState newState,MoveStates state)
    {
        _currentState = newState;
        _currentState?.OnEnterState(this, state);
    }

    private void Update()
    {
        if (_currentState != null) { _currentState?.OnPlayerStateChanged(this); }
    }

    public bool IsGrounded()
    {
        return transform.position.y <= 0.5f;
    }
}
