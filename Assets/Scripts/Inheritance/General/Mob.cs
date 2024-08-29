public abstract class Mob : Entity
{
    protected int _health;
    protected float _movementSpeed;
    
    protected abstract void Move();

    protected override void Attack()
    {
        throw new System.NotImplementedException();
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
        Destroy(gameObject);
    }

    //Здесь ещё будут методы DetectOpponent(), EnterCombat(), ExitCombat().
}