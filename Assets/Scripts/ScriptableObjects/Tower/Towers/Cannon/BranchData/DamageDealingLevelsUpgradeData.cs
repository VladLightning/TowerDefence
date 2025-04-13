

using UnityEngine;

public abstract class DamageDealingLevelsUpgradeData : BranchLevelsUpgradeData
{
    [SerializeField]private DamageTypesEnum _damageType;
    public DamageTypesEnum DamageType => _damageType;
}
