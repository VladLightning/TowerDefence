using System;
using System.Collections;
using UnityEngine;
public abstract class Tower : Entity
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileLaunchPoint;

    private float _force;
    private float _range;
    private int _price;
    private int _rotationSpeed;

    private Transform _target;
    private CircleCollider2D _collider2D;

    private IEnumerator _shoot;
    private IEnumerator _deactivate;
    private bool _isActive;

    public void Initiate(TowerData towerData)
    {
        _damage = towerData.Damage;
        _attackSpeed = towerData.AttackSpeed;
        _damageType = towerData.DamageType;
        _force = towerData.Force;
        _range = towerData.Range;
        _price = towerData.Price;
        _rotationSpeed = towerData.RotationSpeed;

        _collider2D = GetComponent<CircleCollider2D>();
        _collider2D.radius = _range;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            FindTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _target = null;
            _deactivate = ShootingDeactivateTimer();
            StartCoroutine(_deactivate);
        }
    }

    private void Start()
    {
        _shoot = Shoot();
        _deactivate = ShootingDeactivateTimer();
    }

    private void Update()
    {
        if(_target != null)
        {
            LookAtTarget();
            if (!_isActive)
            {
                Attack();
            }
        }
    }

    private void FindTarget()
    {
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, _range, LayerMask.GetMask("Enemy"));

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
        StopCoroutine(_deactivate);
    }

    private void LookAtTarget()
    {
        Vector2 targetDirection = _target.position - transform.position;
       
        float angle = Vector2.SignedAngle(transform.up, targetDirection);
       
        transform.Rotate(Vector3.forward, angle * _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(_attackSpeed);
            GameObject projectile = Instantiate(_projectile, _projectileLaunchPoint.position, _projectileLaunchPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.up * _force);
        }
    }
    private IEnumerator ShootingDeactivateTimer()
    {
        yield return new WaitForSeconds(_attackSpeed);
        _isActive = false;
        StopCoroutine(_shoot);
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
        _isActive = true;
        StartCoroutine(_shoot);
    }
}
