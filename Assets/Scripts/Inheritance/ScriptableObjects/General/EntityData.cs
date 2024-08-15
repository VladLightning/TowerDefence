using UnityEngine;

public abstract class EntityData : ScriptableObject
{
    [SerializeField] protected int _damage;
    public int Damage => _damage;

    [SerializeField] protected float _attackSpeed;
    public float AttackSpeed => _attackSpeed;

    [SerializeField] protected DamageTypeEnum.DamageTypes _damageType;
    public DamageTypeEnum.DamageTypes DamageType => _damageType;
}