
public class WindTowerBuffAbility : TowerBuffBranchAbility
{
    private WindTowerBuffAbilityLevelData _windTowerBuffAbilityLevelData;
    
    private float _totalAttackDelayCoefficientBuff;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _windTowerBuffAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as WindTowerBuffAbilityLevelData;

        _totalAttackDelayCoefficientBuff = _windTowerBuffAbilityLevelData.AttackDelayCoefficientBuff[0];
    }
    
    protected override void ApplyBuff(Tower tower)
    {
        tower.ChangeAttackDelayCoefficient(_totalAttackDelayCoefficientBuff);
    }

    protected override void RemoveBuff(Tower tower)
    {
        tower.ChangeAttackDelayCoefficient(1/_totalAttackDelayCoefficientBuff);
    }

    protected override void CalculateTotalCoefficients(int currentUpgradeLevel)
    {
        _totalAttackDelayCoefficientBuff *= _windTowerBuffAbilityLevelData.AttackDelayCoefficientBuff[currentUpgradeLevel];
        
        foreach (var tower in _towers)
        {
            tower.ChangeAttackDelayCoefficient(_windTowerBuffAbilityLevelData.AttackDelayCoefficientBuff[currentUpgradeLevel]);
        }
    }
}
