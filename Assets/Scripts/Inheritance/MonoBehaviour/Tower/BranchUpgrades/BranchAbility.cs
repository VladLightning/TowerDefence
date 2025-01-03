using UnityEngine;

public abstract class BranchAbility : MonoBehaviour
{
    public abstract void Initiate(BranchUpgradeData branchUpgradeData);

    public abstract void Upgrade();
}
