using System.Collections.Generic;
using UnityEngine;

public class FrostTowerBuffAbility : UpgradeableBranchAbility
{
    private FrostTowerBuffAbilityLevelData _frostTowerBuffAbilityLevelData;

    private readonly List<Tower> _towers = new List<Tower>();
    
    private float _totalDamageCoefficientBuff;
    private float _totalAttackSpeedCoefficientBuff;

    private void Start()
    {
        var collider = GetComponent<CircleCollider2D>();
        collider.enabled = false;
        collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            var tower = other.GetComponent<Tower>();
            ChangeTowerCoefficients(tower, _totalDamageCoefficientBuff, _totalAttackSpeedCoefficientBuff);
            _towers.Add(tower);
        }
    }

    private void OnDisable()
    {
        foreach (var tower in _towers)
        {
            ChangeTowerCoefficients(tower, 1/_totalDamageCoefficientBuff, 1/_totalAttackSpeedCoefficientBuff);
        }
    }

    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _frostTowerBuffAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as FrostTowerBuffAbilityLevelData;

        _totalDamageCoefficientBuff = _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[0].DamageCoefficientBuff;
        _totalAttackSpeedCoefficientBuff = _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[0].AttackSpeedCoefficientBuff;
    }

    public override void Upgrade(int levelIndex)
    {
        CalculateTotalCoefficients(levelIndex);
    }

    private void CalculateTotalCoefficients(int currentUpgradeLevel)
    {
        _totalDamageCoefficientBuff *= _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].DamageCoefficientBuff;
        _totalAttackSpeedCoefficientBuff *= _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].AttackSpeedCoefficientBuff;
        
        foreach (var tower in _towers)
        {
            ChangeTowerCoefficients(tower, _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].DamageCoefficientBuff, 
                                     _frostTowerBuffAbilityLevelData.FrostTowerBuffLevels[currentUpgradeLevel].AttackSpeedCoefficientBuff);
        }
    }
    
    private void ChangeTowerCoefficients(Tower tower, float damageCoefficient, float attackSpeedCoefficient)
    {
        tower.ChangeDamageCoefficient(damageCoefficient);
        tower.ChangeAttackSpeedCoefficient(attackSpeedCoefficient);
    }
}
