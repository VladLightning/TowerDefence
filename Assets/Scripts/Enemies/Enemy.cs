
using UnityEngine;

public abstract class Enemy : Mob
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    private Transform _currentPoint;
    private Path _path;
    private PlayerHealth _playerHealth;

    private int _currentPointIndex;

    private int _damageToPlayer;
    private int _moneyOnDeath;

    public void Initiate(EnemyData enemyData, Path path, PlayerHealth playerHealth)
    {
        _damage = enemyData.Damage;
        _attackSpeed = enemyData.AttackSpeed;
        _damageType = enemyData.DamageType;
        _health = enemyData.Health;
        _attackSpeed = enemyData.AttackSpeed;
        _damageToPlayer = enemyData.DamageToPlayer;
        _moneyOnDeath = enemyData.MoneyOnDeath;
        _movementSpeed = enemyData.MovementSpeed;

        _path = path;
        _playerHealth = playerHealth;
    }

    private void Start()
    {
        _currentPoint = _path.PathPoints[_currentPointIndex];
        transform.position = _currentPoint.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _movementSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _currentPoint.position) < DISTANCE_THRESHOLD)
        {
            _currentPointIndex++;
            if (_currentPointIndex == _path.PathPoints.Length)
            {
                DealDamageToPlayer();               
                return;
            }
            _currentPoint = _path.PathPoints[_currentPointIndex];
        }
    }

    private void DealDamageToPlayer()
    {
        _playerHealth.TakeDamage(_damageToPlayer);
        Destroy(gameObject);
    }
}