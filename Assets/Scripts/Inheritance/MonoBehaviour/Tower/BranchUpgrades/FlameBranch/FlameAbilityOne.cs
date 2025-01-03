using UnityEngine;

public class FlameAbilityOne : BranchAbility
{
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        Debug.Log("Init");
    }

    public override void Upgrade()
    {
        Debug.Log("Upgrade");
    }
}
