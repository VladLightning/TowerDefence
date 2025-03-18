
using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public abstract class Mob : Entity, IDamageDealer
{
    
    protected MobStatesEnum.MobStates _currentState;
    public MobStatesEnum.MobStates CurrentState => _currentState;

    private DamageTypesEnum.DamageTypes _damageType;
    public DamageTypesEnum.DamageTypes DamageType => _damageType;
    
    private Mob _opponent;
    public Mob Opponent => _opponent;

    private Coroutine _fight;

    private int _damage;
    public int Damage => _damage;
    
    protected float _damageCoefficient = 1;
    
    protected int _maxHealth;
    public int MaxHealth => _maxHealth;
    protected int _currentHealth;
    public int CurrentHealth => _currentHealth;
    private float _defaultMovementSpeed;
    protected float _currentMovementSpeed;

    private SerializedDictionary<DamageTypesEnum.DamageTypes, float> _defaultDamageResistances;

    private SerializedDictionary<DamageTypesEnum.DamageTypes, float> _currentDamageResistances = new();
    
    protected HealthbarView _healthBarView;

    protected abstract void Move(Vector2 target);
    
    protected override void Initiate()
    {
        base.Initiate();
        
        var mobData = _entityData as MobData;
        
        _maxHealth = mobData.Health;
        _currentHealth = _maxHealth;
        
        _damageType = mobData.DamageType;
        _damage = mobData.Damage;
        
        _defaultMovementSpeed = mobData.MovementSpeed;
        _currentMovementSpeed = _defaultMovementSpeed;

        _defaultDamageResistances = mobData.Resistances;
        foreach (var resistanceType in _defaultDamageResistances)
        {
            _currentDamageResistances.Add(resistanceType.Key, resistanceType.Value);
        }
        
        _healthBarView = GetComponentInChildren<HealthbarView>();
        _healthBarView.SetMaxHealth(_maxHealth);
    }

    protected void LookAtTarget(Vector2 target)
    {
        transform.localScale =
            (target.x < transform.position.x)
                ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y)
                : new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        
        _healthBarView.AlignHealthBar();
    }

    public virtual void TakeDamage(int damage, DamageTypesEnum.DamageTypes damageType)
    {
        if (_currentHealth <= 0)
        {
            return;
        }

        float currentResistance = (_currentDamageResistances[damageType] < 1) ? _currentDamageResistances[damageType] : 1;
        
        _currentHealth -= (int)(damage * (1 - currentResistance)); 
        _healthBarView.UpdateHealthBar(_currentHealth);
        
        if(_currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(int healingAmount)
    {
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
            return;
        }
        
        _currentHealth += healingAmount;
        _healthBarView.UpdateHealthBar(_currentHealth);
    }

    protected virtual void Death()
    {
        //Анимации, звуки
    }
    
    protected void DecreaseMovementSpeed(float coefficient)
    {
        _currentMovementSpeed *= coefficient;
    }

    protected void SetMovementSpeedToDefault()
    {
        _currentMovementSpeed = _defaultMovementSpeed;
    }

    private IEnumerator Fight(Mob opponent)
    {
        while (true)
        {
            yield return new WaitForSeconds(_attackDelay);
            opponent.TakeDamage(_damage, _damageType);
        }
    }

    public void IncreaseDamageResistance(float coefficient, DamageTypesEnum.DamageTypes damageType)
    {
        _currentDamageResistances[damageType] += coefficient;
    }

    public void DecreaseDamageResistance(float coefficient, DamageTypesEnum.DamageTypes damageType)
    {
        _currentDamageResistances[damageType] -= coefficient;
    }
    
    public void Revive()
    {
        _currentHealth = _maxHealth;
        _healthBarView.UpdateHealthBar(_currentHealth);
        gameObject.SetActive(true);
    }
    
    public virtual void EnterCombat(Mob target)
    {
        _opponent = target;
        ChangeState(MobStatesEnum.MobStates.Fighting);
        LookAtTarget(_opponent.transform.position);
        
        _fight = StartCoroutine(Fight(target));
    }

    public virtual void ExitCombat()
    {
        if (_fight != null)
        {
            StopCoroutine(_fight);
        }
    }

    public void ChangeState(MobStatesEnum.MobStates newState)
    {
        _currentState = newState;
    }
}