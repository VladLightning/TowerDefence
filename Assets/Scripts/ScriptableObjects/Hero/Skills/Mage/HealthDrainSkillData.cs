
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Hero/Skills/Active/HealthDrainSkill", order = 2)]
public class HealthDrainSkillData : ScriptableObject
{
    [SerializeField] private GameObject _healthDrainVisualPrefab;
    public GameObject HealthDrainVisualPrefab => _healthDrainVisualPrefab;
    [SerializeField] private float _triggerChance;
    public float TriggerChance => _triggerChance;
    [SerializeField] private float _healthDrainPercentage;
    public float HealthDrainPercentage => _healthDrainPercentage;
    [SerializeField] private float _healthDrainLimit;
    public float HealthDrainLimit => _healthDrainLimit;
}
