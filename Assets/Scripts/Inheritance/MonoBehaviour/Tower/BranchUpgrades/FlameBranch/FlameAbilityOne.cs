using UnityEngine;

public class FlameAbilityOne : BranchAbility
{
    private StatusProjectileData _statusProjectileData;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _statusProjectileData = branchUpgradeData as FlameAbilityOneData;
        GetComponent<Tower>().SetStatusProjectile(_statusProjectileData);
    }

    public override void Upgrade()
    {
        Debug.Log("Upgrade");
    }
}
