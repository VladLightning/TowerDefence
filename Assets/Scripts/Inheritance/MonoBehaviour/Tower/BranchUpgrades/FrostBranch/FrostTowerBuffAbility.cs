
public class FrostTowerBuffAbility : TowerBuffBranchAbility
{
    private FrostTowerBuffAbilityLevelData _frostTowerBuffAbilityLevelData;
    
    private float _totalDamageCoefficientBuff;
    private float _totalAttackDelayCoefficientBuff;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _frostTowerBuffAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as FrostTowerBuffAbilityLevelData;

        _totalDamageCoefficientBuff = _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[0].DamageCoefficientBuff;
        _totalAttackDelayCoefficientBuff = _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[0].AttackDelayCoefficientBuff;
    }

    protected override void ApplyBuff(Tower tower)
    {
        ChangeTowerCoefficients(tower, _totalDamageCoefficientBuff, _totalAttackDelayCoefficientBuff);
    }

    protected override void RemoveBuff(Tower tower)
    {
        ChangeTowerCoefficients(tower, 1/_totalDamageCoefficientBuff, 1/_totalAttackDelayCoefficientBuff);
    }

    protected override void CalculateTotalCoefficients(int currentUpgradeLevel)
    {
        _totalDamageCoefficientBuff *= _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].DamageCoefficientBuff;
        _totalAttackDelayCoefficientBuff *= _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].AttackDelayCoefficientBuff;
        
        foreach (var tower in _towers)
        {
            ChangeTowerCoefficients(tower, _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].DamageCoefficientBuff, 
                                     _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].AttackDelayCoefficientBuff);
        }
    }
    
    private void ChangeTowerCoefficients(Tower tower, float damageCoefficient, float attackDelayCoefficient)
    {
        tower.ChangeDamageCoefficient(damageCoefficient);
        tower.ChangeAttackDelayCoefficient(attackDelayCoefficient);
    }
}
