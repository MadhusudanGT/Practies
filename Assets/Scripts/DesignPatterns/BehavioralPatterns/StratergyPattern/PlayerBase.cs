using UnityEngine;

public interface PlayerBase
{
    public abstract MoveStates Name { get; set; }
    void Update();
    void HandleInput();
}
