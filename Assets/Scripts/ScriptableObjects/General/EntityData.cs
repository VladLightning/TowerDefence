using UnityEngine;

public abstract class EntityData : ScriptableObject
{
    [SerializeField] protected float _attackDelay;
    public float AttackDelay => _attackDelay;
}