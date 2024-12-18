using UnityEngine;
using System;
using System.Collections;

public abstract class Enemy : Mob
{
    public static event Action OnDecreaseEnemyAmount;
    public static event Action<int> OnDealDamageToPlayer;
    public static event Action<int> OnDeath;
    
    private const float DISTANCE_THRESHOLD = 0.1f;

    private Transform _currentPoint;
    private Path _path;

    private int _currentPointIndex;

    private int _damageToPlayer;
    private int _moneyOnDeath;

    public void Initiate(Path path)
    {
        _path = path;
    }

    protected override void SetStats()
    {
        base.SetStats();

        var enemyData = _entityData as EnemyData;
        
        _damageToPlayer = enemyData.DamageToPlayer;
        _moneyOnDeath = enemyData.MoneyOnDeath;
    }

    private void Start()
    {
        _currentPoint = _path.PathPoints[_currentPointIndex];
        transform.position = _currentPoint.position;
    }

    private void FixedUpdate()
    {
        if (_currentState == MobStatesEnum.MobStates.Moving)
        {
            Move(_currentPoint.position);
        }
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

    public void StartSlowDownMovement(float speedReductionCoefficient, float speedReductionDuration)
    {
        StartCoroutine(SlowDownMovement(speedReductionCoefficient, speedReductionDuration));
    }

    private IEnumerator SlowDownMovement(float speedReductionCoefficient, float speedReductionDuration)
    {
        DecreaseMovementSpeed(speedReductionCoefficient);
        yield return new WaitForSeconds(speedReductionDuration);
        SetMovementSpeedToDefault();
    }

    protected override void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _currentMovementSpeed * Time.deltaTime);

        UpdatePath();
    }

    private void UpdatePath()
    { 
        LookAtTarget(_currentPoint.position);
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