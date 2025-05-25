
public class VoidTowerBuffAbility : TowerBuffBranchAbility
{
    private VoidTowerBuffAbilityLevelData _voidTowerBuffAbilityLevelData;
    
    private float _totalDamageCoefficientBuff;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _voidTowerBuffAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as VoidTowerBuffAbilityLevelData;

        _totalDamageCoefficientBuff = _voidTowerBuffAbilityLevelData.DamageCoefficientBuff[0];
    }
    
    protected override void ApplyBuff(Tower tower)
    {
        tower.ChangeDamageCoefficient(_totalDamageCoefficientBuff);
    }

    protected override void RemoveBuff(Tower tower)
    {
        tower.ChangeDamageCoefficient(1/_totalDamageCoefficientBuff);
    }

    protected override void CalculateTotalCoefficients(int currentUpgradeLevel)
    {
        _totalDamageCoefficientBuff *= _voidTowerBuffAbilityLevelData.DamageCoefficientBuff[currentUpgradeLevel];
        
        foreach (var tower in _towers)
        {
            tower.ChangeDamageCoefficient(_voidTowerBuffAbilityLevelData.DamageCoefficientBuff[currentUpgradeLevel]);
        }
    }
}
