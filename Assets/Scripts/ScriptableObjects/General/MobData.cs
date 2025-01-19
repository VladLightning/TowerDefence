using UnityEngine;
public abstract class MobData : EntityData
{
    [SerializeField] protected int _health;
    public int Health => _health;
    [SerializeField] protected float _movementSpeed;
    public float MovementSpeed => _movementSpeed;
    
    [SerializeField] protected int _damage;
    public int Damage => _damage;
    
    [SerializeField] protected DamageTypesEnum.DamageTypes _damageType;
    public DamageTypesEnum.DamageTypes DamageType => _damageType;
}
