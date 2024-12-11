using UnityEngine;
[CreateAssetMenu(fileName = "AbilityData", menuName = "CastleCannonAbilityData")]
public class CastleCannonAbilityData : AoEAbilityData
{
    [SerializeField] private LayerMask _mask;
    public LayerMask Mask => _mask;
    
    [SerializeField] private float _explosionForce;
    public float ExplosionForce => _explosionForce;
    
    [SerializeField] private int _explosionDamage;
    public int ExplosionDamage => _explosionDamage;
}
