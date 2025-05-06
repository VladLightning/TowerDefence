
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/ElementalSlime")]
public class ElementalSlimeData : ExplosiveEnemyData
{
    [SerializeField] private DamageTypesEnum _ownElement;
    public DamageTypesEnum OwnElement => _ownElement;
    [SerializeField] private float _percentOfHealthAsDamage;
    public float PercentOfHealthAsDamage => _percentOfHealthAsDamage;
}
