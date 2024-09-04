using System;
using System.Collections;
using UnityEngine;
public abstract class Tower : Entity
{
    private const float DELAY_FOR_ROTATION = 0.2f;
    private const float SELL_PRICE_COEFFICIENT = 0.5f;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileLaunchPoint;

    private float _force;
    private float _range;
    private int _price;
    private int _rotationSpeed;

    private int _towerLevelIndex;
    public int TowerLevelIndex => _towerLevelIndex;

    private float _lastShotTime;

    private Transform _target;
    private CircleCollider2D _collider2D;

    private PlayerMoney _playerMoney;
    private TowerLevels[] _towerLevels;
    public TowerLevels[] TowerLevels => _towerLevels;

    private IEnumerator _shoot;
    private bool _shootingIsActive;

    public void Initiate(TowerData towerData, PlayerMoney playerMoney)
    {
        SetStats(towerData);

        _playerMoney = playerMoney;

        _collider2D = GetComponent<CircleCollider2D>();
        _collider2D.radius = _range;
    }

    private void SetStats(TowerData towerData)
    {
        _damage = towerData.Damage;
        _attackSpeed = towerData.AttackSpeed;
        _damageType = towerData.DamageType;
        _force = towerData.Force;
        _range = towerData.Range;
        _price = towerData.Price;
        _rotationSpeed = towerData.RotationSpeed;

        _towerLevels = towerData.TowerLevels;
    }
    private void SetStats()
    {
        _damage = _towerLevels[_towerLevelIndex].Damage;
        _attackSpeed = _towerLevels[_towerLevelIndex].AttackSpeed;
        _damageType = _towerLevels[_towerLevelIndex].DamageType;
        _force = _towerLevels[_towerLevelIndex].Force;
        _range = _towerLevels[_towerLevelIndex].Range;
        _price += _towerLevels[_towerLevelIndex].Price;
        _rotationSpeed = _towerLevels[_towerLevelIndex].RotationSpeed;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform == _target)
        {
            FindTarget();
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
            yield return new WaitForSeconds(delay);
            FindTarget();
            yield return new WaitForSeconds(DELAY_FOR_ROTATION);

            var projectile = Instantiate(_projectile, _projectileLaunchPoint.position, _projectileLaunchPoint.rotation).GetComponent<Projectile>();
            projectile.Initialize(_force, _damage);

            _lastShotTime = Time.time;          
            delay = _attackSpeed;
        }
    }
    
    private void DeactivateShoot()
    {
        _shootingIsActive = false;
        StopCoroutine(_shoot);
    }

    public void Upgrade()
    {
        _playerMoney.Purchase(_towerLevels[_towerLevelIndex].Price);
        SetStats();
        _towerLevelIndex++;
    }

    public void Sell()
    {
        _playerMoney.AddMoney((int)(SELL_PRICE_COEFFICIENT * _price));
        Destroy(gameObject);
    }

    protected override void Attack()
    {       
        float delay = (Time.time - _lastShotTime > _attackSpeed) ? 0 : _attackSpeed - (Time.time - _lastShotTime);

        _shoot = Shoot(delay);
        StartCoroutine(_shoot);
    }
}
