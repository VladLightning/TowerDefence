
public abstract class UpgradeableBranchAbility : BranchAbility
{
    public abstract override void Initiate(BranchUpgradeData branchUpgradeData);
    public abstract void Upgrade(int levelIndex);
}
