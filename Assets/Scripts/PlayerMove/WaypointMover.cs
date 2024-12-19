using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] Transform _targetObj;
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] int curentWayPointIndex = 0;
    private void Update()
    {
        if (wayPoints.Count <= 0)
        {
            return;
        }

        Transform wayPoint = wayPoints[curentWayPointIndex];
        _targetObj.position = Vector3.MoveTowards(_targetObj.position, wayPoint.position, Time.deltaTime);

        if (Vector3.Distance(_targetObj.position, wayPoint.position) < 0.1f)
        {
            curentWayPointIndex = (curentWayPointIndex + 1) % wayPoints.Count;
        }
    }
}
