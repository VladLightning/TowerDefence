using UnityEngine;
[CreateAssetMenu(fileName = "AbilityData", menuName = "Ability")]
public class AbilityData : ScriptableObject
{
    [SerializeField] private float _abilityCooldown;
    public float AbilityCooldown => _abilityCooldown;

    [SerializeField] private Sprite _abilityIcon;
    public Sprite AbilityIcon => _abilityIcon;
}
