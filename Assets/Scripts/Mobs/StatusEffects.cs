using System.Collections;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    private Mob _mob;
    
    private void Start()
    {
        _mob = GetComponent<Mob>();
    }

    public void TriggerEffect(StatusProjectileStats statusProjectileStats, DamageTypesEnum.DamageTypes damageType)
    {
        switch (damageType)
        {
            case DamageTypesEnum.DamageTypes.Flame:
                
                StartCoroutine(BurningEffect(statusProjectileStats));
                break;
            case DamageTypesEnum.DamageTypes.Frost:
                
                break;
        }
    }

    private IEnumerator BurningEffect(StatusProjectileStats statusProjectileStats)
    {
        for (int i = 0; i < statusProjectileStats.StatusTicksAmount; i++)
        {
            yield return new WaitForSeconds(statusProjectileStats.StatusTickInterval);
            _mob.TakeDamage(statusProjectileStats.StatusDamage);
        }
    }
}
