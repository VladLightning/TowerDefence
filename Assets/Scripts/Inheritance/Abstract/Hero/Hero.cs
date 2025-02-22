using System;
using System.Collections;
using UnityEngine;
public abstract class Hero : Mob
{
    private const float DISTANCE_THRESHOLD = 0.1f;
    
    public static event Action<float, GameObject> OnDeath;

    private IEnumerator _move;
    private Coroutine _regenerate;
    
    private float _respawnTime;
    private float _regenerationDelay;
    private float _regenerationInterval;
    private int _regenerationAmount;
    
    private HeroDetectOpponent _heroDetectOpponent;
    protected IActiveHeroSkill _activeSkill;
    protected IPassiveHeroSkill _passiveSkill;

    protected override void Initiate()
    {
        base.Initiate();
        var heroData = _entityData as HeroData;
        
        _respawnTime = heroData.RespawnTime;
        _regenerationDelay = heroData.RegenerationDelay;
        _regenerationInterval = heroData.RegenerationInterval;
        _regenerationAmount = heroData.RegenerationAmount;
        
        _heroDetectOpponent = GetComponentInChildren<HeroDetectOpponent>();
        
        _activeSkill = GetComponent<IActiveHeroSkill>();
        _passiveSkill = GetComponent<IPassiveHeroSkill>();
    }

    private void OnEnable()
    {
        MouseInput.OnPathSelected += Move;
    }

    private void OnDisable()
    {
        MouseInput.OnPathSelected -= Move;
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
        _heroDetectOpponent.SearchPotentialOpponent();
    }
    
    private IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(_regenerationDelay);
        
        while (_currentHealth < _maxHealth)
        {
            yield return new WaitForSeconds(_regenerationInterval);
            _currentHealth += _regenerationAmount;
            _healthBarView.UpdateHealthBar(_currentHealth);
        }
        _currentHealth = _maxHealth;
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

    protected override void Death()
    {
        OnDeath?.Invoke(_respawnTime, gameObject);
        gameObject.SetActive(false);
    }
    
    public override void EnterCombat(Mob target)
    {
        base.EnterCombat(target);
        
        if (_regenerate != null)
        {
            StopCoroutine(_regenerate);
        }
    }

    public override void ExitCombat()
    {
        base.ExitCombat();

        if (gameObject.activeSelf)
        {
            _regenerate = StartCoroutine(RegenerateHealth());
        }
    }
}