using UnityEngine;
[CreateAssetMenu(fileName = "AbilityData", menuName = "CastleCannonAbilityData")]
public class CastleCannonAbilityData : AbilityData
{
    [SerializeField] private LayerMask _mask;
    public LayerMask Mask => _mask;
    
    [SerializeField] private float _explosionForce;
    public float ExplosionForce => _explosionForce;
    
    [SerializeField] private float _explosionRadius;
    public float ExplosionRadius => _explosionRadius;
    
    [SerializeField] private int _explosionDamage;
    public int ExplosionDamage => _explosionDamage;
}
