
public abstract class DamageDealingBranchAbility : UpgradeableBranchAbility
{
    protected DamageTypesEnum.DamageTypes _damageType;
    
    public abstract override void Initiate(BranchUpgradeData branchUpgradeData);

    public abstract override void Upgrade(int levelIndex);
}
