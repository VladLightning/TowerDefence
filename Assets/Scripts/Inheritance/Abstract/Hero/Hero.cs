using System;
using System.Collections;
using UnityEngine;
public abstract class Hero : Mob
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    private IEnumerator _move;

    private float _skillCooldown;
    private float _respawnTime;
    private float _regenerationDelay;
    private float _regenerationInterval;
    private int _regenerationAmount;
    
    private HeroDetectOpponent _heroDetectOpponent;

    protected override void SetStats()
    {
        base.SetStats();
        var heroData = _entityData as HeroData;
        
        _skillCooldown = heroData.SkillCooldown;
        _respawnTime = heroData.RespawnTime;
        _regenerationDelay = heroData.RegenerationDelay;
        _regenerationInterval = heroData.RegenerationInterval;
        _regenerationAmount = heroData.RegenerationAmount;
    }

    private void OnEnable()
    {
        MouseInput.OnPathSelected += Move;
    }

    private void OnDisable()
    {
        MouseInput.OnPathSelected -= Move;
    }

    private void Start()
    {
        _heroDetectOpponent = GetComponentInChildren<HeroDetectOpponent>();
    }

    private IEnumerator MoveHero(Vector2 targetPosition)
    {
        ChangeState(MobStatesEnum.MobStates.Moving);
        while (Vector2.Distance(transform.position, targetPosition) > DISTANCE_THRESHOLD)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _currentMovementSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        ChangeState(MobStatesEnum.MobStates.Idle);
    }

    private void Skill()
    {
        throw new System.NotImplementedException();
    }

    private void RegenerateHealth()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move(Vector2 target)
    {
        if (_move != null)
        {
            StopCoroutine(_move);
        }
        
        LookAtTarget(target);
        _move = MoveHero(target);
        StartCoroutine(_move);
        
        _heroDetectOpponent.StopFighting();
    }
}