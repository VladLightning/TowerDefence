using System;
using UnityEngine;
public abstract class Tower : Entity
{
    [SerializeField] private GameObject _projectile;
    private float _range;
    private int _price;
    private int _rotationSpeed;

    private Transform _target;
    private CircleCollider2D _collider2D;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void Update()
    {
        FindTarget();
        if(_target != null)
        {
            LookAtTarget();
        }
    }

    private void FindTarget()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, _range, LayerMask.GetMask("Enemy"));

        if(enemyColliders.Length == 0)
        {
            _target = null;
            return;
        }

        float shortestDistance = enemyColliders[0].GetComponent<Enemy>().GetDistanceToCastle();
        float newDistance;
        int shortestDistanceIndex = 0;

        for (int i = 1; i < enemyColliders.Length; i++)
        {          
            newDistance = enemyColliders[i].GetComponent<Enemy>().GetDistanceToCastle();
            if (shortestDistance > newDistance)
            {
                shortestDistance = newDistance;
                shortestDistanceIndex = i;
            }
        }
        _target = enemyColliders[shortestDistanceIndex].transform;
    }

    private void LookAtTarget()
    {
        Vector2 targetDirection = _target.position - transform.position;
       
        float angle = Vector2.SignedAngle(transform.up, targetDirection);
       
        transform.Rotate(Vector3.forward, angle * _rotationSpeed * Time.deltaTime);
    }

    public void Initiate(TowerData towerData)
    {
        _damage = towerData.Damage;
        _attackSpeed = towerData.AttackSpeed;
        _damageType = towerData.DamageType;
        _range = towerData.Range;
        _price = towerData.Price;
        _rotationSpeed = towerData.RotationSpeed;

        _collider2D = GetComponent<CircleCollider2D>();
        _collider2D.radius = _range;
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
