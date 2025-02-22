
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Active/ResistanceSkill", order = 1)]
public class ResistanceSkillData : CooldownSkillData
{

    [SerializeField] private float _duration;
    public float Duration => _duration;
    [SerializeField] private float _resistanceCoefficient;
    public float ResistanceCoefficient => _resistanceCoefficient;
}
