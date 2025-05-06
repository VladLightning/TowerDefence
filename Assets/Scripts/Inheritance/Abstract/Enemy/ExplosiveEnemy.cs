
using UnityEngine;

public abstract class ExplosiveEnemy : Enemy
{
    private float _explosionRadius;
    private float _explosionForce;
    private LayerMask _layerMask;
    
    protected override void Initiate()
    {
        base.Initiate();
        
        var explosiveEnemyData = _entityData as ExplosiveEnemyData;

        _explosionRadius = explosiveEnemyData.ExplosionRadius;
        _explosionForce = explosiveEnemyData.ExplosionForce;
        _layerMask = explosiveEnemyData.LayerMask;
    }
    
   
    protected void Explode(int explosionDamage)
    {
        var enemies = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, _layerMask);

        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(explosionDamage, DamageType);
            enemy.attachedRigidbody.AddForce(CalculateExplosionForceDirection(enemy.transform.position) * _explosionForce);
        }
    }
    
    private Vector2 CalculateExplosionForceDirection(Vector2 targetPosition)
    {
        return (targetPosition - (Vector2)transform.position).normalized;
    }
}
