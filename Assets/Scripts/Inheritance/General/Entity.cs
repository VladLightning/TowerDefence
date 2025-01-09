using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityData _entityData;
    
    protected float _attackSpeed;
    
    protected virtual void Awake()
    {
        SetStats();
    }

    protected virtual void SetStats()
    {
        _attackSpeed = _entityData.AttackSpeed;
    }
}
