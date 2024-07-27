using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] _pathPoints;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 1; i < _pathPoints.Length; i++)
        {           
            Gizmos.DrawLine(_pathPoints[i - 1].position, _pathPoints[i].position);         
        }
    }

    public Transform GetStartPoint()
    {
        return _pathPoints[0];
    }

    public Transform GetNextPoint(Transform currentPoint)
    {
        if(currentPoint.GetSiblingIndex() < _pathPoints.Length - 1)
        {
            return _pathPoints[currentPoint.GetSiblingIndex() + 1];
        }
        else
        {
            return null;
        }
    }
}
