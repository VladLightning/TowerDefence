using System.Collections;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    private Mob _mob;

    private StatusProjectileStats _statusProjectileStats;
    
    private MobStatusesEnum.MobStatuses _currentStatus;
    
    private void Start()
    {
        _mob = GetComponent<Mob>();
    }

    public void TriggerEffect(StatusProjectileStats statusProjectileStats, DamageTypesEnum.DamageTypes damageType)
    {
        _statusProjectileStats = statusProjectileStats;

        switch (damageType)
        {
            case DamageTypesEnum.DamageTypes.Physical:
                _currentStatus = MobStatusesEnum.MobStatuses.None;
                break;
            case DamageTypesEnum.DamageTypes.Flame:
                _currentStatus = MobStatusesEnum.MobStatuses.Aflame;
                StartCoroutine(BurningEffect());
                break;
            case DamageTypesEnum.DamageTypes.Frost:
                _currentStatus = MobStatusesEnum.MobStatuses.Frozen;
                break;
        }
    }

    private IEnumerator BurningEffect()
    {
        for (int i = 0; i < _statusProjectileStats.StatusTicksAmount; i++)
        {
            yield return new WaitForSeconds(_statusProjectileStats.StatusTickInterval);
            _mob.TakeDamage(_statusProjectileStats.StatusDamage);
        }
    }
}
