using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private Transform[] _routeWaypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint;

    private void Update()
    {
        Move();
    }

    [ContextMenu("Refresh Route Waypoints")]
    private void RefreshRouteWaypoints()
    {
        int waypointsCount = _route.childCount;
        _routeWaypoints = new Transform[waypointsCount];

        for (int i = 0; i < waypointsCount; i++)
            _routeWaypoints[i] = _route.GetChild(i);
    }

    private void Move()
    {
        Transform target = _routeWaypoints[_currentWaypoint];

        if (transform.position == target.position)
        {
            _currentWaypoint = ++_currentWaypoint % _routeWaypoints.Length;
            transform.forward = Rotate() - transform.position;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private Vector3 Rotate()
    {
        return _routeWaypoints[_currentWaypoint].transform.position;
    }
}
