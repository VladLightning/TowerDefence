using UnityEngine;
using System;
public abstract class Enemy : Mob
{
    public static event Action OnDecreaseEnemyAmount;
    public static event Action<int> OnDealDamageToPlayer;
    public static event Action<int> OnDeath;
    
    private const float DISTANCE_THRESHOLD = 0.1f;

    [SerializeField] private EnemyData _enemyData;

    private Transform _currentPoint;
    private Path _path;

    private int _currentPointIndex;

    private int _damageToPlayer;
    private int _moneyOnDeath;

    public void Initiate(Path path)
    {
        SetStats(_enemyData);

        _path = path;
    }

    private void SetStats(EnemyData enemyData)
    {
        _damage = enemyData.Damage;
        _attackSpeed = enemyData.AttackSpeed;
        _damageType = enemyData.DamageType;
        _health = enemyData.Health;
        _damageToPlayer = enemyData.DamageToPlayer;
        _moneyOnDeath = enemyData.MoneyOnDeath;
        _movementSpeed = enemyData.MovementSpeed;
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

    private void DealDamageToPlayer()
    {
        OnDealDamageToPlayer?.Invoke(_damageToPlayer);
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        OnDecreaseEnemyAmount?.Invoke();
        Destroy(gameObject);
    }

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _movementSpeed * Time.deltaTime);

        if (!(Vector2.Distance(transform.position, _currentPoint.position) < DISTANCE_THRESHOLD))
        {
            return;
        }
        if (_currentPointIndex == _path.PathPoints.Length - 1)
        {
            DealDamageToPlayer();  
            return;
        }
        _currentPointIndex++;
        _currentPoint = _path.PathPoints[_currentPointIndex];
    }

    protected override void Death()
    {
        base.Death();

        OnDeath?.Invoke(_moneyOnDeath);
        DestroyEnemy();
    }

    public float GetDistanceToCastle()
    {
        return _path.DistancesBetweenPoints[_currentPointIndex - 1] + Vector2.Distance(transform.position, _path.PathPoints[_currentPointIndex].position);
    }
}