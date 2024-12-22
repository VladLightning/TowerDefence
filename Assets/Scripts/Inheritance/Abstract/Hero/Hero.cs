using System.Collections;
using UnityEngine;
public abstract class Hero : Mob
{
    private const float DISTANCE_THRESHOLD = 0.1f;

    private IEnumerator _move;
    private IEnumerator _regenerate;

    private float _skillCooldown;
    private float _respawnTime;
    private float _regenerationDelay;
    private float _regenerationInterval;
    private int _regenerationAmount;
    
    private bool _isRegenerating;
    
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
        
        _heroDetectOpponent = GetComponentInChildren<HeroDetectOpponent>();
    }

    private void Start()
    {
        _regenerate = RegenerateHealth();
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

    private void TryStartRegeneration(MobStatesEnum.MobStates newState)
    {
        if (newState == MobStatesEnum.MobStates.Idle && _currentHealth < _maxHealth && !_isRegenerating)
        {
            StartCoroutine(_regenerate);
        }
        else if(newState == MobStatesEnum.MobStates.Fighting)
        {
            StopCoroutine(_regenerate);
            _regenerate = RegenerateHealth();
            _isRegenerating = false;
        }
    }
    
    private IEnumerator RegenerateHealth()
    {
        _isRegenerating = true;
        yield return new WaitForSeconds(_regenerationDelay);
        
        while (_isRegenerating)
        {
            yield return new WaitForSeconds(_regenerationInterval);
            _currentHealth += _regenerationAmount;
            _healthbarView.UpdateHealthBar(_currentHealth);
            
            if (_currentHealth < _maxHealth)
            {
                continue;
            }
            
            _isRegenerating = false;
            _currentHealth = _maxHealth;
            StopCoroutine(_regenerate);
        }
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
        Destroy(gameObject);
    }
    
    public override void ChangeState(MobStatesEnum.MobStates newState)
    {
        base.ChangeState(newState);
        TryStartRegeneration(newState);
    }
}