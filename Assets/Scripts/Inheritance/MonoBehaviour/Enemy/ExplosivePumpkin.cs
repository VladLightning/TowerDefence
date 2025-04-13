
using UnityEngine;

public class ExplosivePumpkin : Enemy
{
    private float _takeDamageChance;
    private float _explosionRadius;
    private float _explosionForce;

    private int _guaranteedDamageHit;

    private int _currentHitsAbsorbedAmount;
    private int _totalDamageNegated;
    
    private LayerMask _layerMask;

    protected override void Initiate()
    {
        base.Initiate();
        
        var explosivePumpkinData = _entityData as ExplosivePumpkinData;
        
        _takeDamageChance = explosivePumpkinData.TakeDamageChance;
        _explosionRadius = explosivePumpkinData.ExplosionRadius;
        _explosionForce = explosivePumpkinData.ExplosionForce;
        _guaranteedDamageHit = explosivePumpkinData.GuaranteedDamageHit;
        
        _layerMask = explosivePumpkinData.LayerMask;
    }
    
    public override void TakeDamage(int damage, DamageTypesEnum damageType)
    {
        _totalDamageNegated += damage;
        _currentHitsAbsorbedAmount++;
        if (Random.value < _takeDamageChance || _guaranteedDamageHit <= _currentHitsAbsorbedAmount)
        {
            base.TakeDamage(damage, damageType);
        }
    }

    protected override void Death()
    {
        Explode();
        base.Death();
    }

    private void Explode()
    {
        var enemies = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, _layerMask);

        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_totalDamageNegated, DamageType);
            enemy.attachedRigidbody.AddForce(CalculateExplosionForceDirection(enemy.transform.position) * _explosionForce);
        }
    }

    private Vector2 CalculateExplosionForceDirection(Vector2 targetPosition)
    {
        return (targetPosition - (Vector2)transform.position).normalized;
    }
}
