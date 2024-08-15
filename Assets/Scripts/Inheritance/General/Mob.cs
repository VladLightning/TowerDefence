public abstract class Mob : Entity
{
    protected int _health;
    protected float _movementSpeed;
    
    protected abstract void Move();

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    protected void Death()
    {
        throw new System.NotImplementedException();
    }

    //Здесь ещё будут методы DetectOpponent(), EnterCombat(), ExitCombat().
}