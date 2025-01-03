using UnityEngine;

public class FlameAbilityThree : BranchAbility
{
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        Debug.Log("init 3");
    }

    public override void Upgrade()
    {
        Debug.Log("upgrade 3");
    }
}
