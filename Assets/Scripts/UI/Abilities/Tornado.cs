using UnityEngine;

public class Tornado : MonoBehaviour
{
    public void TornadoActivate(LayerMask mask, float tornadoForceMagnitude, float tornadoDuration, float tornadoRadius)
    {
        var pointEffector = GetComponent<PointEffector2D>();
        pointEffector.colliderMask = mask;
        pointEffector.forceMagnitude = tornadoForceMagnitude;
        
        GetComponent<CircleCollider2D>().radius = tornadoRadius;
        
        Destroy(gameObject, tornadoDuration);
    }
}
