
using System.Collections;
using UnityEngine;

public abstract class Mob : Entity
{
    
    protected MobStatesEnum.MobStates _currentState;
    public MobStatesEnum.MobStates CurrentState => _currentState;
    
    protected DamageTypesEnum.DamageTypes _damageType;
    
    private Mob _opponent;
    public Mob Opponent => _opponent;

    private Coroutine _fight;

    private int _damage;
    protected int _maxHealth;
    protected int _currentHealth;
    private float _defaultMovementSpeed;
    protected float _currentMovementSpeed;

    private float _damageResistance;
    
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

    public virtual void TakeDamage(int damage)
    {
        if (_currentHealth <= 0)
        {
            return;
        }
        
        //Todo resist > 1, all resist types 
        _currentHealth -= (int)(damage * (1 - _damageResistance)); 
        _healthBarView.UpdateHealthBar(_currentHealth);
        
        if(_currentHealth <= 0)
        {
            Death();
        }
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
            yield return new WaitForSeconds(_attackSpeed);
            opponent.TakeDamage(_damage);
        }
    }

    public void IncreaseDamageResistance(float coefficient)
    {
        _damageResistance += coefficient;
    }

    public void DecreaseDamageResistance(float coefficient)
    {
        _damageResistance -= coefficient;
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