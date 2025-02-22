
public class Knight : Hero
{
    private IPassiveHeroSkillDeactivatable PassiveSkillDeactivatable => _passiveSkill as IPassiveHeroSkillDeactivatable;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        if (_currentHealth <= _maxHealth/2 && _currentHealth > 0)
        {
            _activeSkill.ActiveSkillTrigger();
        }
    }

    public override void EnterCombat(Mob target)
    {
        base.EnterCombat(target);
        PassiveSkillDeactivatable.Activate();
    }

    public override void ExitCombat()
    {
        base.ExitCombat();
        PassiveSkillDeactivatable.Deactivate();
    }
}