using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float rayDistance = 50f;
    public Color rayCastColor;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRay(Input.mousePosition);
        }
    }

    void ShootRay(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * rayDistance, rayCastColor, 2f);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }

            Debug.DrawLine(ray.origin, hit.point, Color.green, 2f); 
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance, rayCastColor, 2f);
        }
    }
}
