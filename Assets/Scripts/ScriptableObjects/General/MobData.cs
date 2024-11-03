using UnityEngine;
public abstract class MobData : EntityData
{
    [SerializeField] protected int _health;
    public int Health => _health;
    [SerializeField] protected float _movementSpeed;
    public float MovementSpeed => _movementSpeed;
}
