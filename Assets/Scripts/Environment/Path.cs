using UnityEngine;

public class Path : MonoBehaviour
{
    private Transform[] _pathPoints;

    public Transform[] PathPoints { get { return _pathPoints; } }

    private void Awake()
    {
        SetPath();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
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
}
