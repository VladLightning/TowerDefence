
using UnityEngine;

public class ResistanceShred : MonoBehaviour, IPassiveHeroSkillDeactivatable
{
    [SerializeField] private ResistanceShredSkillData _resistanceShredSkillData;
    
    private float _resistanceShredCoefficient;
    
    private Hero _hero;
    
    private void Start()
    {
        _resistanceShredCoefficient = _resistanceShredSkillData.ResistanceShredCoefficient;
        _hero = GetComponent<Hero>();
    }

    public void Activate()
    {
        _hero.Opponent.DecreaseDamageResistance(_resistanceShredCoefficient);
    }

    public void Deactivate()
    {
        _hero.Opponent.IncreaseDamageResistance(_resistanceShredCoefficient);
    }
}
