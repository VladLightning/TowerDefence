
using UnityEngine;

public abstract class CooldownSkillData : ScriptableObject
{

    [SerializeField] protected float _cooldown;
    public float Cooldown => _cooldown;
}
