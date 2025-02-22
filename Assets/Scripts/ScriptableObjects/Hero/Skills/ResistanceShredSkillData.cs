
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Passive/ResistanceShredSkill", order = 1)]
public class ResistanceShredSkillData : ScriptableObject
{

    [SerializeField] private float _resistanceShredCoefficient;
    public float ResistanceShredCoefficient => _resistanceShredCoefficient;
}
