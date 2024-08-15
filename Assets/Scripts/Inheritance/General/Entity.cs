using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    protected int _damage;
    protected float _attackSpeed;

    protected DamageTypeEnum.DamageTypes _damageType;

    protected abstract void Attack();
}
