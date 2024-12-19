using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] PlayerMovementData _playerControllerData;
    [SerializeField] Transform _bulletPrefab;
    private Rigidbody _rigidBody;
    private bool isGrounded = true;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * _playerControllerData.movementSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * _playerControllerData.movementSpeed * Time.deltaTime;
        transform.Translate(moveZ, 0, moveX);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            _rigidBody?.AddForce(Vector3.up * _playerControllerData.jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void Fire()
    {
       Transform bullet = Instantiate(_bulletPrefab, _playerControllerData.firePoint.position, _playerControllerData.firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = _playerControllerData.firePoint.forward * _playerControllerData.bulletSpeed;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
