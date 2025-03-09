
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Active/ArrowRain", order = 2)]
public class ArrowRainData : CooldownSkillData
{
    [SerializeField] private GameObject _arrowRainPrefab;
    public GameObject ArrowRainPrefab => _arrowRainPrefab;
    [SerializeField] private float _damage;
    public float Damage => _damage;
    [SerializeField] private float _areaRadius;
    public float AreaRadius => _areaRadius;
}
