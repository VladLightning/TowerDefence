
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Active/ArrowRain", order = 2)]
public class ArrowRainSkillData : CooldownSkillData
{
    [SerializeField] private GameObject _arrowRainPrefab;
    public GameObject ArrowRainPrefab => _arrowRainPrefab;
    [SerializeField] private ArrowRainData _arrowRainData;
    public ArrowRainData ArrowRainData => _arrowRainData;
}
