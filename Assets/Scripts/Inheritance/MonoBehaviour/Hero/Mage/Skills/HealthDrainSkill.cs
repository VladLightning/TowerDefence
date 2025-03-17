
using UnityEngine;

public class HealthDrainSkill : MonoBehaviour, IActiveHeroSkill
{
    [SerializeField] private HealthDrainSkillData _healthDrainSkillData;

    private GameObject _healthDrainVisualPrefab;
    
    private float _triggerChance;
    private float _healthDrainPercentage;
    private float _healthDrainLimit;

    private RangedHero _rangedHero;
    private RangedHeroDetectShootingTarget _rangedHeroDetectShootingTarget;

    private void Start()
    {
        _healthDrainVisualPrefab = _healthDrainSkillData.HealthDrainVisualPrefab;
        _triggerChance = _healthDrainSkillData.TriggerChance;
        _healthDrainPercentage = _healthDrainSkillData.HealthDrainPercentage;
        _healthDrainLimit = _healthDrainSkillData.HealthDrainLimit;
        
        _rangedHero = GetComponentInParent<RangedHero>();
        _rangedHeroDetectShootingTarget = GetComponent<RangedHeroDetectShootingTarget>();
    }

    public void ActiveSkillTrigger()
    {
        TryActivateHealthDrain();
    }

    private void TryActivateHealthDrain()
    {
        if (Random.value < _triggerChance)
        {
            DrainHealth();
        }
    }

    private void DrainHealth()
    {
        var enemy = _rangedHeroDetectShootingTarget.TargetToShoot.GetComponent<Enemy>();
            
        Instantiate(_healthDrainVisualPrefab, enemy.transform);
            
        enemy.TakeDamage((int)(enemy.CurrentHealth * _healthDrainPercentage), _rangedHero.DamageType);
            
        _rangedHero.Heal(CalculateHealingAmount(enemy));
    }

    private int CalculateHealingAmount(Enemy enemy)
    {
        int healingAmount = (int)(enemy.CurrentHealth * _healthDrainPercentage);

        if (healingAmount > _rangedHero.MaxHealth * _healthDrainLimit)
        {
            healingAmount = (int)(_rangedHero.MaxHealth * _healthDrainLimit);
        }
        return healingAmount;
    }
}
