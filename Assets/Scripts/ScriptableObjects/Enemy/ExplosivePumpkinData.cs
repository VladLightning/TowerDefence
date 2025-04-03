using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/ExplosivePumpkin")]
public class ExplosivePumpkinData : EnemyData
{
    [SerializeField] private float _takeDamageChance;
    public float TakeDamageChance => _takeDamageChance;
    [SerializeField] private float _explosionRadius;
    public float ExplosionRadius => _explosionRadius;
    [SerializeField] private float _explosionForce;
    public float ExplosionForce => _explosionForce;
    [SerializeField] private int _guaranteedDamageHit;
    public int GuaranteedDamageHit => _guaranteedDamageHit;
    [SerializeField] private LayerMask _layerMask;
    public LayerMask LayerMask => _layerMask;
}
