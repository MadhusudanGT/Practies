using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(_camera.position, desiredPosition, smoothSpeed);
        _camera.position = smoothedPosition;

        _camera.LookAt(target);
    }
}
