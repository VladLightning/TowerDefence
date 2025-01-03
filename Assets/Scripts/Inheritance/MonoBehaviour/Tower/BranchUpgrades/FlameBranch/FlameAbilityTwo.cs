using UnityEngine;

public class FlameAbilityTwo : BranchAbility
{
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        Debug.Log("init 2");
    }

    public override void Upgrade()
    {
        Debug.Log("upgrade 2");
    }
}
