using UnityEngine;

public class Tornado : MonoBehaviour
{
    public void TornadoActivate(LayerMask mask, float tornadoForceMagnitude, float tornadoDuration)
    {
        var pointEffector = GetComponent<PointEffector2D>();
        pointEffector.colliderMask = mask;
        pointEffector.forceMagnitude = tornadoForceMagnitude;
        
        Destroy(gameObject, tornadoDuration);
    }
}
