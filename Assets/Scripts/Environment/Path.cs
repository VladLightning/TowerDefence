using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Color _pathGizmoColor;
    private Transform[] _pathPoints;

    public Transform[] PathPoints { get { return _pathPoints; } }

    private float[] _distancesBetweenPoints;
    public float[] DistancesBetweenPoints => _distancesBetweenPoints;

    private void Awake()
    {
        SetPath();
        CalculateDistancesBetweenPoints();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _pathGizmoColor;
        for (int i = 1; i < transform.childCount; i++)
        {           
            Gizmos.DrawLine(transform.GetChild(i - 1).position, transform.GetChild(i).position);         
        }
    }

    private void SetPath()
    {
        _pathPoints = new Transform[transform.childCount];
        for (int i = 0; i < _pathPoints.Length; i++)
        {
            _pathPoints[i] = transform.GetChild(i);
        }
    }

    private void CalculateDistancesBetweenPoints()
    {
        _distancesBetweenPoints = new float[_pathPoints.Length-1];
        _distancesBetweenPoints[^1] = 0;
        for(int i = 2; i < _distancesBetweenPoints.Length+1; i++)
        {
            _distancesBetweenPoints[^i] = Vector2.Distance(_pathPoints[^i].position, _pathPoints[^(i - 1)].position) + _distancesBetweenPoints[^(i-1)];
        }
    }
}
