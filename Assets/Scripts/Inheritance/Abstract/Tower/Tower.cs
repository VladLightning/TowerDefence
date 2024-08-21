using System;
using UnityEngine;
public abstract class Tower : Entity
{
    [SerializeField] private GameObject _projectile;
    private float _range;
    private int _price;
    private int _rotationSpeed;

    private Transform _target;
    private Collider2D _collider2D;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && _target == null)
        {
            _target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && _target != null)
        {
            _target = null;
            FindTarget();
        }
    }

    private void Update()
    {
        if(_target != null)
        {
            LookAtTarget();
        }
    }

    private void FindTarget()
    {
        _collider2D.enabled = false;
        _collider2D.enabled = true;
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

        GetComponent<CircleCollider2D>().radius = _range;
        _collider2D = GetComponent<CircleCollider2D>();
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
