using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    protected int _damage;
    protected float _attackSpeed;

    [SerializeField] protected EntityData _entityData;
    
    protected DamageTypeEnum.DamageTypes _damageType;
    
    protected abstract void Attack();

    protected virtual void Awake()
    {
        SetStats();
    }

    protected virtual void SetStats()
    {
        _damage = _entityData.Damage;
        _attackSpeed = _entityData.AttackSpeed;
        _damageType = _entityData.DamageType;
    }
}
