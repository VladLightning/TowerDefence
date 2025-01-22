
public class StatusProjectileAbility : BranchAbility
{
    private StatusProjectileData _statusProjectileData;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _statusProjectileData = branchUpgradeData.BranchLevelsUpgradeData as StatusProjectileData;
        GetComponent<Tower>().SetStatusProjectile(_statusProjectileData);
    }
}
