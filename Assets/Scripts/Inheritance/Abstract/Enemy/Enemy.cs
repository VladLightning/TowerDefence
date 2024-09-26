using UnityEngine;
public abstract class Enemy : Mob
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    [SerializeField] private EnemyData _enemyData;

    private Transform _currentPoint;
    private Path _path;
    private PlayerHealth _playerHealth;
    private PlayerMoney _playerMoney;

    private int _currentPointIndex;

    private int _damageToPlayer;
    private int _moneyOnDeath;

    public void Initiate(Path path, PlayerHealth playerHealth, PlayerMoney playerMoney)
    {
        SetStats(_enemyData);

        _path = path;
        _playerHealth = playerHealth;
        _playerMoney = playerMoney;
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
        _playerHealth.TakeDamage(_damageToPlayer);
        Destroy(gameObject);
    }

    protected override void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentPoint.position, _movementSpeed * Time.deltaTime);     

        if (Vector2.Distance(transform.position, _currentPoint.position) < DISTANCE_THRESHOLD)
        {          
            if (_currentPointIndex == _path.PathPoints.Length - 1)
            {
                DealDamageToPlayer();               
                return;
            }
            _currentPointIndex++;
            _currentPoint = _path.PathPoints[_currentPointIndex];
        }
    }

    protected override void Death()
    {
        _playerMoney.AddMoney(_moneyOnDeath);
        base.Death();
    }

    public float GetDistanceToCastle()
    {
        return _path.DistancesBetweenPoints[_currentPointIndex - 1] + Vector2.Distance(transform.position, _path.PathPoints[_currentPointIndex].position);
    }
}