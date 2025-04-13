using AYellowpaper.SerializedCollections;
using UnityEngine;
public abstract class MobData : EntityData
{
    [SerializeField] protected int _health;
    public int Health => _health;
    [SerializeField] protected float _movementSpeed;
    public float MovementSpeed => _movementSpeed;
    
    [SerializeField] protected int _damage;
    public int Damage => _damage;
    
    [SerializeField] protected DamageTypesEnum _damageType;
    public DamageTypesEnum DamageType => _damageType;

    [SerializeField] protected SerializedDictionary<DamageTypesEnum, float> _resistances;
    public SerializedDictionary<DamageTypesEnum, float> Resistances => _resistances;
}
