using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Scriptable Objects/PlayerMovementData")]
public class PlayerMovementData : ScriptableObject
{
    public float movementSpeed;
    public float jumpForce;

    public Transform firePoint;
    public float bulletSpeed;
}
