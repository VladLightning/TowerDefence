using UnityEngine;
public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityData _entityData;
    
    protected float _attackSpeed;
    
    protected virtual void Awake()
    {
        Initiate();
    }

    protected virtual void Initiate()
    {
        _attackSpeed = _entityData.AttackSpeed;
    }
}
