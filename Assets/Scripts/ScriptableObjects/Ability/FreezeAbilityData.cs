
using UnityEngine;
[CreateAssetMenu(fileName = "AbilityData", menuName = "FreezeAbilityData")]
public class FreezeAbilityData : AbilityData
{
    [SerializeField] private LayerMask _mask;
    public LayerMask Mask => _mask;
    
    [SerializeField] private float _movementSpeedReductionCoefficient;
    public float MovementSpeedReductionCoefficient => _movementSpeedReductionCoefficient;
    
    [SerializeField] private float _freezeRadius;
    public float FreezeRadius => _freezeRadius;
    
    [SerializeField] private float _freezeDuration;
    public float FreezeDuration => _freezeDuration;
}
