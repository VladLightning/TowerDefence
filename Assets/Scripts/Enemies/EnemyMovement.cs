using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private const float DISTANCE_THRESHOLD = 0.1f;
 
    [SerializeField] private float _speed;

    private Transform _currentPoint;
    private Path _path;

    private int _currentPointIndex;

    public Path Path { set { _path = value; } }

    private void Start()
    {
        _currentPoint = _path.PathPoints[_currentPointIndex];
        transform.position = _currentPoint.position;       
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, _currentPoint.position) < DISTANCE_THRESHOLD)
        {
            _currentPointIndex++;
            if ( _currentPointIndex == _path.PathPoints.Length)
            {
                GetComponent<EnemyDamage>().DealDamage();
                Destroy(gameObject);
                return;
            }
            _currentPoint = _path.PathPoints[_currentPointIndex];
        }
    }
}
