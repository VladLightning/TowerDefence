using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] _pathPoints;

    public Transform[] PathPoints { get { return _pathPoints; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 1; i < _pathPoints.Length; i++)
        {           
            Gizmos.DrawLine(_pathPoints[i - 1].position, _pathPoints[i].position);         
        }
    }
}
