using System.Collections;
using UnityEngine;

public abstract class Mob : Entity
{
    
    protected MobStatesEnum.MobStates _currentState;
    public MobStatesEnum.MobStates CurrentState => _currentState;
    
    private GameObject _opponent;

    private Coroutine _fight;
    
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
        if (_health <= 0)
        {
            return;
        }
        
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

    private IEnumerator Fight(Mob opponent)
    {
        while (true)
        {
            yield return new WaitForSeconds(_attackSpeed);
            opponent.TakeDamage(_damage);
        }
    }
    
    public void EnterCombat(GameObject target)
    {
        _opponent = target;
        ChangeState(MobStatesEnum.MobStates.Fighting);
        LookAtTarget(_opponent.transform.position);
        
        _fight = StartCoroutine(Fight(target.GetComponent<Mob>()));
    }

    public void ExitCombat()
    {
        if (_fight == null)
        {
            return;
        }
        StopCoroutine(_fight);
    }

    public void ChangeState(MobStatesEnum.MobStates newState)
    {
        _currentState = newState;
    }
}