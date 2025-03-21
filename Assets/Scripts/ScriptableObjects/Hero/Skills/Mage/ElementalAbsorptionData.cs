
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Passive/ElementalAbsorption", order = 2)]
public class ElementalAbsorptionData : ScriptableObject
{
    [SerializeField] private SerializedDictionary<DamageTypesEnum.DamageTypes, GameObject> _elementalProjectiles;
    public SerializedDictionary<DamageTypesEnum.DamageTypes, GameObject> ElementalProjectiles => _elementalProjectiles;
    [SerializeField] private SerializedDictionary<DamageTypesEnum.DamageTypes, StatusProjectileStats> _projectilesStats;
    public SerializedDictionary<DamageTypesEnum.DamageTypes, StatusProjectileStats> ProjectilesStats => _projectilesStats;
    [SerializeField] private SerializedDictionary<DamageTypesEnum.DamageTypes, float> _elementalResistancesCoefficients;
    public SerializedDictionary<DamageTypesEnum.DamageTypes, float> ElementalResistancesCoefficients => _elementalResistancesCoefficients;
    [SerializeField] private LayerMask _layerMask;
    public LayerMask LayerMask => _layerMask;
    [SerializeField] private float _radius;
    public float Radius => _radius;
}
