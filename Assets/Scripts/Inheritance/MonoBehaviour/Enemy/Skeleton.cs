public class Skeleton : Enemy
{
    public override void TakeDamage(int damage, DamageTypesEnum damageType)
    {
        base.TakeDamage(damage, damageType);
        AdjustResistance(damage, damageType);
    }

    private void AdjustResistance(int damage, DamageTypesEnum damageType)
    {
        float damageTaken = damage * (1 - _currentDamageResistances[damageType]);
        float resistanceIncreaseCoefficient = damageTaken/_maxHealth;
        IncreaseDamageResistance(resistanceIncreaseCoefficient, damageType);
    }
}
