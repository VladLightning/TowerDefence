using UnityEngine;
public abstract class AbilityData : ScriptableObject
{
    [SerializeField] private float _abilityCooldown;
    public float AbilityCooldown => _abilityCooldown;

    [SerializeField] private Sprite _abilityIcon;
    public Sprite AbilityIcon => _abilityIcon;
}
