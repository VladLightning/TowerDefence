
using System.Collections;
using UnityEngine;

public class ResistanceIncrease : MonoBehaviour, IActiveHeroSkill
{
    [SerializeField] private ResistanceSkillData _resistanceSkillData;
    
    private float _skillCooldown;
    private float _skillDuration;
    
    private float _resistanceCoefficient;
    
    private bool _isResistant;
    
    private Hero _hero;

    private void Start()
    {
        _skillCooldown = _resistanceSkillData.Cooldown;
        _skillDuration = _resistanceSkillData.Duration;
        
        _resistanceCoefficient = _resistanceSkillData.ResistanceCoefficient;
        
        _hero = GetComponent<Hero>();
    }

    public void ActiveSkillTrigger()
    {
        if (!_isResistant)
        {
            StartCoroutine(IncreaseResistance());
        }
    }

    private IEnumerator IncreaseResistance()
    {
        _isResistant = true;
        
        _hero.IncreaseDamageResistance(_resistanceCoefficient);
        yield return new WaitForSeconds(_skillDuration);
        _hero.DecreaseDamageResistance(_resistanceCoefficient);
        yield return new WaitForSeconds(_skillCooldown);
        
        _isResistant = false;
    }
}
