using System.Collections.Generic;
using UnityEngine;

public class FrostTowerBuffAbility : UpgradeableBranchAbility
{
    private FrostTowerBuffAbilityLevelData _frostTowerBuffAbilityLevelData;

    private List<Tower> _towers = new List<Tower>();
    private Tower _towerSelf;
    
    private float _totalDamageCoefficientBuff;
    private float _totalAttackSpeedCoefficientBuff;
    
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
    
    private void Start()
    {
        InitialBuffCast();
    }

    private void InitialBuffCast()
    {
        _towerSelf = GetComponent<Tower>();
        var colliders = Physics2D.OverlapCircleAll(transform.position, _towerSelf.Range, LayerMask.GetMask("Tower"));
        foreach (var collider in colliders)
        {
            AddTower(collider);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TowerBody"))
        {
            AddTower(other);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TowerBody"))
        {
            RemoveTower(other);
        }
    }
    
    private void AddTower(Collider2D collider)
    {
        var tower = collider.gameObject.GetComponentInParent<Tower>();
        ChangeTowerCoefficients(tower, _totalDamageCoefficientBuff, _totalAttackSpeedCoefficientBuff);
        _towers.Add(tower);
    }

    
    private void RemoveTower(Collider2D other)
    {
        var tower = other.GetComponentInParent<Tower>();
        ChangeTowerCoefficients(tower, 1/_totalDamageCoefficientBuff, 1/_totalAttackSpeedCoefficientBuff);
        _towers.Remove(tower);
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
