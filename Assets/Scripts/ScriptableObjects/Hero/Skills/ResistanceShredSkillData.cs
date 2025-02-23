
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Passive/ResistanceShredSkill", order = 1)]
public class ResistanceShredSkillData : ScriptableObject
{
    [SerializeField] private float _shredCoefficient;
    public float ShredCoefficient => _shredCoefficient;

    [SerializeField] private DamageTypesEnum.DamageTypes _resistanceShredType;
    public DamageTypesEnum.DamageTypes ResistanceShredType => _resistanceShredType;
}
