using System;
using System.Collections;
using UnityEngine;

public abstract class Mob : Entity
{
    private const float START_COMBAT_DELAY = 0.1f;
    
    protected MobStatesEnum.MobStates _currentState;
    public MobStatesEnum.MobStates CurrentState => _currentState;
    
    private GameObject _opponent;
    
    private IEnumerator _enterCombat;
    private bool _isEnteringCombat;
    
    private int _health;
    private float _defaultMovementSpeed;
    protected float _currentMovementSpeed;

    protected abstract void Move(Vector2 target);

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
    
    protected override void SetStats()
    {
        base.SetStats();
        
        var mobData = _entityData as MobData;
        
        _health = mobData.Health;
        _defaultMovementSpeed = mobData.MovementSpeed;
        _currentMovementSpeed = _defaultMovementSpeed;
    }

    protected void LookAtTarget(Vector2 target)
    {
        transform.localScale =
            (target.x < transform.position.x)
                ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y)
                : new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
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

    public void StartEnterCombat(GameObject target)
    {
        if (_currentState == MobStatesEnum.MobStates.Fighting || _enterCombat != null || _isEnteringCombat)
        {
            return;
        }
        
        _enterCombat = EnterCombat(target);
        StartCoroutine(_enterCombat);
    }
    
    private IEnumerator EnterCombat(GameObject target)
    {
        _isEnteringCombat = true;
        
        yield return new WaitForSeconds(START_COMBAT_DELAY); //Задержка для того, чтобы гарантировать, что оппоненты встретятся, несмотря на разницу в размерах коллайдеров моделек
        
        _opponent = target;
        _currentState = MobStatesEnum.MobStates.Fighting;
        LookAtTarget(_opponent.transform.position);
        
        _enterCombat = null;
        _isEnteringCombat = false;
    }

    public void ExitCombat(GameObject target)
    {
        if (_opponent != target)
        {
            return;
        }
        
        _currentState = MobStatesEnum.MobStates.Moving;
    }
}