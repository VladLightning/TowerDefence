using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "VoidTowerResistanceShredData", menuName = "AbilityLevelsData/VoidTowerResistanceShred", order = 7)]

public class VoidTowerResistanceShredAbilityLevelData : BranchLevelsUpgradeData
{
    [SerializeField] private ResistanceShreds[] _resistanceShreds;
    public ResistanceShreds[] ResistanceShredsStats => _resistanceShreds;

    [System.Serializable]
    public class ResistanceShreds
    {
        [SerializeField] private SerializedDictionary<DamageTypesEnum, float> _shreds;
        public SerializedDictionary<DamageTypesEnum, float> Shreds => _shreds;
    }
}
