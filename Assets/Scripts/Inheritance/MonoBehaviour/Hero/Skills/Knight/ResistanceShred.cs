
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class ResistanceShred : MonoBehaviour, IPassiveHeroSkillDeactivatable
{
    [SerializeField] private ResistanceShredSkillData _resistanceShredSkillData;
    
    private SerializedDictionary<DamageTypesEnum.DamageTypes, float> _resistanceShredTypes;
    
    private Hero _hero;
    
    private void Start()
    {
        _resistanceShredTypes = _resistanceShredSkillData.ResistanceShredTypes;
        _hero = GetComponent<Hero>();
    }

    public void Activate()
    {
        foreach (var damageType in _resistanceShredTypes)
        {
            _hero.Opponent.DecreaseDamageResistance(damageType.Value, damageType.Key);
        }
    }

    public void Deactivate()
    {
        foreach (var damageType in _resistanceShredTypes.Keys)
        {
            _hero.Opponent.ResetDamageResistance(damageType);
        }
    }
}
