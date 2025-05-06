
public class ElementalSlime : ExplosiveEnemy
{
    private StatusEffects _statusEffects;
    
    private DamageTypesEnum _potentialCauseOfDeath;
    
    private DamageTypesEnum _ownElement;
    private float _percentOfHealthAsDamage;
    
    protected override void Initiate()
    {
        base.Initiate();
        
        _statusEffects = GetComponent<StatusEffects>();
        
        var elementalSlimeData = _entityData as ElementalSlimeData;

        _ownElement = elementalSlimeData.OwnElement;
        _percentOfHealthAsDamage = elementalSlimeData.PercentOfHealthAsDamage;
    }

    public override void TakeDamage(int damage, DamageTypesEnum damageType)
    {
        _potentialCauseOfDeath = damageType;
        base.TakeDamage(damage, damageType);
    }
    
    protected override void Death()
    {
        if (_ownElement == _potentialCauseOfDeath)
        {
            Explode(CalculateDamage());
        }
        base.Death();
    }

    private int CalculateDamage()
    {
        return (int)(_percentOfHealthAsDamage * _maxHealth * _statusEffects.StatusEffectsDictionary[_ownElement]);
    }
}
