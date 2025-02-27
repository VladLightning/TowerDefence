
using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class ResistanceIncrease : MonoBehaviour, IActiveHeroSkill
{
    [SerializeField] private ResistanceSkillData _resistanceSkillData;
    
    private SerializedDictionary<DamageTypesEnum.DamageTypes, float> _resistanceTypes;
    
    private float _skillCooldown;
    private float _skillDuration;
    
    private bool _isResistant;
    
    private Hero _hero;

    private void Start()
    {
        _skillCooldown = _resistanceSkillData.Cooldown;
        _skillDuration = _resistanceSkillData.Duration;
        
        _resistanceTypes = _resistanceSkillData.ResistanceTypes;
        
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

        foreach (var damageType in _resistanceTypes)
        {
            _hero.IncreaseDamageResistance(damageType.Value, damageType.Key);
        }
        
        yield return new WaitForSeconds(_skillDuration);
        
        foreach (var damageType in _resistanceTypes)
        {
            _hero.DecreaseDamageResistance(damageType.Value, damageType.Key);
        }
        
        yield return new WaitForSeconds(_skillCooldown);
        
        _isResistant = false;
    }
}
