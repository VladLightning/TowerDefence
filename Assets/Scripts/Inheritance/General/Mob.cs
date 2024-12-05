using UnityEngine;

public abstract class Mob : Entity
{
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

    //Здесь ещё будут методы DetectOpponent(), EnterCombat(), ExitCombat().
}