

using UnityEngine;

public abstract class DamageDealingLevelsUpgradeData : BranchLevelsUpgradeData
{
    [SerializeField]private DamageTypesEnum.DamageTypes _damageType;
    public DamageTypesEnum.DamageTypes DamageType => _damageType;
}
