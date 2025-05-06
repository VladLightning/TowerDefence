
using UnityEngine;

public class ExplosivePumpkin : ExplosiveEnemy
{
    private float _takeDamageChance;

    private int _guaranteedDamageHit;

    private int _currentHitsAbsorbedAmount;
    private int _totalDamageNegated;
    
    protected override void Initiate()
    {
        base.Initiate();
        
        var explosivePumpkinData = _entityData as ExplosivePumpkinData;
        
        _takeDamageChance = explosivePumpkinData.TakeDamageChance;
        _guaranteedDamageHit = explosivePumpkinData.GuaranteedDamageHit;
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
        Explode(_totalDamageNegated);
        base.Death();
    }
}
