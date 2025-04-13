using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    private Mob _mob;
    [SerializedDictionary("Effect", "Stack")]
    [SerializeField] private SerializedDictionary<DamageTypesEnum, int> _statusEffects = new SerializedDictionary<DamageTypesEnum, int>();
    
    private void Start()
    {
        _mob = GetComponent<Mob>();
    }

    public void TriggerEffect(StatusProjectileStats statusProjectileStats, DamageTypesEnum damageType)
    {
        if (!_statusEffects.TryAdd(damageType, 1))
        {
            _statusEffects[damageType]++;
        }
        
        StartCoroutine(DealDamagePerTick(statusProjectileStats, damageType));
        
        switch (damageType)
        {
            case DamageTypesEnum.Flame:
                
                break;
            case DamageTypesEnum.Frost:
                
                break;
        }
    }

    private IEnumerator DealDamagePerTick(StatusProjectileStats statusProjectileStats, DamageTypesEnum damageType)
    {
        for (int i = 0; i < statusProjectileStats.StatusTicksAmount; i++)
        {
            yield return new WaitForSeconds(statusProjectileStats.StatusTickInterval);
            _mob.TakeDamage(statusProjectileStats.StatusDamage, damageType);
        }
        _statusEffects[damageType]--;

        if (_statusEffects[damageType] == 0)
        {
            _statusEffects.Remove(damageType);
        }
    }
}
