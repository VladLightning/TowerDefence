
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Passive/ElementalAbsorption", order = 2)]
public class ElementalAbsorptionData : ScriptableObject
{
    [SerializeField] private SerializedDictionary<DamageTypesEnum, GameObject> _elementalProjectiles;
    public SerializedDictionary<DamageTypesEnum, GameObject> ElementalProjectiles => _elementalProjectiles;
    [SerializeField] private SerializedDictionary<DamageTypesEnum, StatusProjectileStats> _projectilesStats;
    public SerializedDictionary<DamageTypesEnum, StatusProjectileStats> ProjectilesStats => _projectilesStats;
    [SerializeField] private SerializedDictionary<DamageTypesEnum, float> _elementalResistancesCoefficients;
    public SerializedDictionary<DamageTypesEnum, float> ElementalResistancesCoefficients => _elementalResistancesCoefficients;
    [SerializeField] private LayerMask _layerMask;
    public LayerMask LayerMask => _layerMask;
    [SerializeField] private float _radius;
    public float Radius => _radius;
}
