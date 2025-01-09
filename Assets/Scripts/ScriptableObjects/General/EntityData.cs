using UnityEngine;
public abstract class EntityData : ScriptableObject
{
    [SerializeField] protected float _attackSpeed;
    public float AttackSpeed => _attackSpeed;
}