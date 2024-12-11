using UnityEngine;

public class Tornado : MonoBehaviour
{
    private LayerMask _mask;
    private float _tornadoForceMagnitude;
    private float _tornadoDuration;
    
    public void SetTornadoStats(LayerMask mask, float tornadoForceMagnitude, float tornadoDuration)
    {
        _mask = mask;
        _tornadoForceMagnitude = tornadoForceMagnitude;
        _tornadoDuration = tornadoDuration;
        
        TornadoActivate();
    }

    private void TornadoActivate()
    {
        var pointEffector = GetComponent<PointEffector2D>();
        pointEffector.colliderMask = _mask;
        pointEffector.forceMagnitude = _tornadoForceMagnitude;
        
        Destroy(gameObject, _tornadoDuration);
    }
}
