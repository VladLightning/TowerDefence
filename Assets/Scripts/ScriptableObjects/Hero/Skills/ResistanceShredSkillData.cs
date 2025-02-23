
using AYellowpaper.SerializedCollections;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Passive/ResistanceShredSkill", order = 1)]
public class ResistanceShredSkillData : ScriptableObject
{

    [SerializeField] private SerializedDictionary<DamageTypesEnum.DamageTypes, float> _resistanceShredTypes;
    public SerializedDictionary<DamageTypesEnum.DamageTypes, float> ResistanceShredTypes => _resistanceShredTypes;
}
