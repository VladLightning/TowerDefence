using System;
using UnityEngine;

public abstract class Tower : Entity
{
    [SerializeField] private GameObject _projectile;
    private float _range;
    private int _price;

    private void FindTarget()
    {
        throw new NotImplementedException();
    }

    private void LookAtTarget()
    {
        throw new NotImplementedException();
    }

    public void Initiate(TowerData towerData)
    {
        _damage = towerData.Damage;
        _attackSpeed = towerData.AttackSpeed;
        _damageType = towerData.DamageType;
        _range = towerData.Range;
        _price = towerData.Price;
    }

    private void Upgrade()
    {
        throw new NotImplementedException();
    }

    private void Sell()
    {
        throw new NotImplementedException();
    }

    protected override void Attack()
    {
        throw new NotImplementedException();
    }
}
