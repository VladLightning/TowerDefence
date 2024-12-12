
using UnityEngine;
[CreateAssetMenu(fileName = "AbilityData", menuName = "FreezeAbilityData")]
public class FreezeAbilityData : AoEAbilityData
{
    [SerializeField] private LayerMask _mask;
    public LayerMask Mask => _mask;
    
    [SerializeField] private float _movementSpeedReductionCoefficient;
    public float MovementSpeedReductionCoefficient => _movementSpeedReductionCoefficient;
    
    [SerializeField] private float _freezeDuration;
    public float FreezeDuration => _freezeDuration;
}
