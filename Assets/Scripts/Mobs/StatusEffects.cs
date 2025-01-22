using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    private Mob _mob;
    [SerializedDictionary("Effect", "Stack")]
    [SerializeField] private SerializedDictionary<DamageTypesEnum.DamageTypes, int> _statusEffects = new SerializedDictionary<DamageTypesEnum.DamageTypes, int>();
    
    private void Start()
    {
        _mob = GetComponent<Mob>();
    }

    public void TriggerEffect(StatusProjectileStats statusProjectileStats, DamageTypesEnum.DamageTypes damageType)
    {
        if (!_statusEffects.TryAdd(damageType, 1))
        {
            _statusEffects[damageType]++;
        }
        
        StartCoroutine(DealDamagePerTick(statusProjectileStats, damageType));
        
        switch (damageType)
        {
            case DamageTypesEnum.DamageTypes.Flame:
                
                break;
            case DamageTypesEnum.DamageTypes.Frost:
                
                break;
        }
    }

    private IEnumerator DealDamagePerTick(StatusProjectileStats statusProjectileStats, DamageTypesEnum.DamageTypes damageType)
    {
        for (int i = 0; i < statusProjectileStats.StatusTicksAmount; i++)
        {
            yield return new WaitForSeconds(statusProjectileStats.StatusTickInterval);
            _mob.TakeDamage(statusProjectileStats.StatusDamage);
        }
        _statusEffects[damageType]--;

        if (_statusEffects[damageType] == 0)
        {
            _statusEffects.Remove(damageType);
        }
    }
}
