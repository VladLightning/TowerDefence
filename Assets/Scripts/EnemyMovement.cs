using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    [SerializeField] private Path _path;
    [SerializeField] private float _speed;

    private Transform _currentPoint;

    private void Start()
    {
        _currentPoint = _path.GetNextPoint(_currentPoint);
        transform.position = _currentPoint.position;       
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, _currentPoint.position) < DISTANCE_THRESHOLD)
        {
            _currentPoint = _path.GetNextPoint(_currentPoint);
        }
    }
}
