using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityData _entityData;
    
    protected float _attackDelay;
    
    protected virtual void Awake()
    {
        Initiate();
    }

    protected virtual void Initiate()
    {
        _attackDelay = _entityData.AttackDelay;
    }
}
