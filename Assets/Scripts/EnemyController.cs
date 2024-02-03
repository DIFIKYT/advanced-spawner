using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform[] _waypoints;
    private int _currentWaypoint = 0;

    public void SetWaypoints(Transform[] waypoints)
    {
        _waypoints = waypoints;
    }

    private void Move()
    {
        if (_waypoints == null || _waypoints.Length == 0)
            return;

        if (transform.position == _waypoints[_currentWaypoint].position)
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;

        transform.LookAt(_waypoints[_currentWaypoint]);
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }
}