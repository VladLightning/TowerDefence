
using UnityEngine;

public abstract class ExplosiveEnemyData : EnemyData
{
    [SerializeField] private float _explosionRadius;
    public float ExplosionRadius => _explosionRadius;
    [SerializeField] private float _explosionForce;
    public float ExplosionForce => _explosionForce;
    [SerializeField] private LayerMask _layerMask;
    public LayerMask LayerMask => _layerMask;
}
