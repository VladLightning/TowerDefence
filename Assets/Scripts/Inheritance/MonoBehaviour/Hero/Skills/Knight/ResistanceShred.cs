
using UnityEngine;

public class ResistanceShred : MonoBehaviour, IPassiveHeroSkillDeactivatable
{
    [SerializeField] private ResistanceShredSkillData _resistanceShredSkillData;
    
    private DamageTypesEnum.DamageTypes _resistanceShredType;
    private float _resistanceShredCoefficient;
    
    private Hero _hero;
    
    private void Start()
    {
        _resistanceShredType = _resistanceShredSkillData.ResistanceShredType;
        _resistanceShredCoefficient = _resistanceShredSkillData.ShredCoefficient;
        _hero = GetComponent<Hero>();
    }

    public void Activate()
    {
        _hero.Opponent.DecreaseDamageResistance(_resistanceShredCoefficient, _resistanceShredType);
    }

    public void Deactivate()
    {
        _hero.Opponent.IncreaseDamageResistance(_resistanceShredCoefficient, _resistanceShredType);
    }
}
