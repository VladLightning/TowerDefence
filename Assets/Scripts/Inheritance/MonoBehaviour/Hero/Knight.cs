public class Knight : Hero
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        if (_currentHealth <= _maxHealth/2 && _currentHealth > 0)
        {
            _activeSkill.ActiveSkillTrigger();
        }
    }
}