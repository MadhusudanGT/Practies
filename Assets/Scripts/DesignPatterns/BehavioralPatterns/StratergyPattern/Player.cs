using UnityEngine;

public class Player
{
    PlayerBase _playerBase;

    public Player()
    {
        Debug.Log("Init Player Constructor");
        _playerBase = new IdleState(this, MoveStates.Idle);
    }

    public void SetNewState(PlayerBase newState)
    {
        Debug.Log($"Switched to new state {newState.Name}");
        _playerBase = newState;
    }

    public void Update()
    {
        _playerBase?.HandleInput();
    }

}


public enum MoveStates
{
    Idle,
    Walk,
    Running
}