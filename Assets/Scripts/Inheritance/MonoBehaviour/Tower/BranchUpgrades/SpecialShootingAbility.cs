
public class SpecialShootingAbility : BranchAbility
{
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        GetComponent<Tower>().SetSpecialShootingAbility();
    }
}
