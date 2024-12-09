
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "TornadoAbilityData")]
public class TornadoAbilityData : AbilityData
{
    [SerializeField] private LayerMask _mask;
    public LayerMask Mask => _mask;
    
    [SerializeField] private float _tornadoForceMagnitude;
    public float TornadoForceMagnitude => _tornadoForceMagnitude;
    
    [SerializeField] private float _tornadoDuration;
    public float TornadoDuration => _tornadoDuration;
}
