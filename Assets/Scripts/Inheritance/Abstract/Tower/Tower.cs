using System;
using System.Collections;
using UnityEngine;
public abstract class Tower : Entity
{
    private const float MINIMUM_DELAY_FOR_ROTATION = 0.5f;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileLaunchPoint;

    private float _force;
    private float _range;
    private int _price;
    private int _rotationSpeed;

    private float _lastShotTime;

    private Transform _target;
    private CircleCollider2D _collider2D;

    private IEnumerator _shoot;
    private bool _shootingIsActive;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_shootingIsActive)
        {
            Attack();
        }
    }

    private void Start()
    {
        //Сделано для того, чтобы башне не пришлось ждать задержку выстрела, если враг попадает зону стрельбы в начале жизненного цикла
        _lastShotTime = -_attackSpeed;
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
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, _range, LayerMask.GetMask("Enemy"));

        if(enemyColliders.Length == 0)
        {
            _target = null;
            DeactivateShoot();
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

    private IEnumerator Shoot(float delay)
    {
        _shootingIsActive = true;
        while (true)
        {
            yield return new WaitForSeconds(delay / 2);
            FindTarget();
            yield return new WaitForSeconds(delay / 2);

            var projectile = Instantiate(_projectile, _projectileLaunchPoint.position, _projectileLaunchPoint.rotation).GetComponent<Projectile>();
            projectile.ProjectileFly(_force);
            projectile.Damage = _damage;

            _lastShotTime = Time.time;          
            delay = _attackSpeed;
        }
    }
    
    private void DeactivateShoot()
    {
        _shootingIsActive = false;
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
        float delay = _attackSpeed;

        delay = (Time.time - _lastShotTime > _attackSpeed) ? MINIMUM_DELAY_FOR_ROTATION : _attackSpeed - (Time.time - _lastShotTime);

        _shoot = Shoot(delay);
        StartCoroutine(_shoot);
    }
}
