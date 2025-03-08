
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Passive/HeroRadiusBuff", order = 2)]
public class HeroRadiusBuffData : ScriptableObject
{
    [SerializeField] private float _damageBuffCoefficient;
    public float DamageBuffCoefficient => _damageBuffCoefficient;
    [SerializeField] private float _attackSpeedBuffCoefficient;
    public float AttackSpeedBuffCoefficient => _attackSpeedBuffCoefficient;
    [SerializeField] private float _buffRadius;
    public float BuffRadius => _buffRadius;
}
