
public interface IPassiveHeroSkill
{
    void Activate();
}

public interface IPassiveHeroSkillDeactivatable : IPassiveHeroSkill
{
    
    void Deactivate();
}
