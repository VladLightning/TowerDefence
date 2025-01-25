
public class RapidFireAbility : BranchAbility
{
    private RapidFireAbilityLevelData _rapidFireAbilityLevelData;
    
    private int _currentCapacity;
    
    private float _currentRapidShotInterval;

    private float _currentRapidShotLoadTime;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _rapidFireAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as RapidFireAbilityLevelData;
        
        _currentCapacity = _rapidFireAbilityLevelData.RapidFireStats[0].Capacity;
        _currentRapidShotInterval = _rapidFireAbilityLevelData.RapidFireStats[0].RapidShotInterval;
        _currentRapidShotLoadTime = _rapidFireAbilityLevelData.RapidFireStats[0].RapidShotLoadTime;
    }
}
