using UnityEngine;

public class CharacterState : MonoBehaviour
{
    Player _player;

    private void Start()
    {
        _player = new Player();
    }

    private void Update()
    {
        _player?.Update();
    }
}
