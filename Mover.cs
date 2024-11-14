using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private float _speed;

    private Transform[] _routeWaypoints;
    private int _currentWaypoint;

    private void Awake()
    {
        _routeWaypoints = new Transform[_route.childCount];

        for (int i = 0; i < _routeWaypoints.Length; i++)
            _routeWaypoints[i] = _route.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Transform target = _routeWaypoints[_currentWaypoint];

        if (transform.position == target.position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _routeWaypoints.Length;
            Rotate();
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private Vector3 Rotate()
    {
        Vector3 direction = _routeWaypoints[_currentWaypoint].transform.position;
        transform.forward = direction - transform.position;
        return direction;
    }
}