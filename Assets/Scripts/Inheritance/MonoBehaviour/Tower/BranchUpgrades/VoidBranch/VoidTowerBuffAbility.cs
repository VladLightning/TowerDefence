
using System.Collections.Generic;
using UnityEngine;

public class VoidTowerBuffAbility : UpgradeableBranchAbility
{
    private VoidTowerBuffAbilityLevelData _voidTowerBuffAbilityLevelData;

    private List<Tower> _towers = new List<Tower>();
    private Tower _towerSelf;
    
    private float _totalDamageCoefficientBuff;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _voidTowerBuffAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as VoidTowerBuffAbilityLevelData;

        _totalDamageCoefficientBuff = _voidTowerBuffAbilityLevelData.DamageCoefficientBuff[0];
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
        tower.ChangeDamageCoefficient(_totalDamageCoefficientBuff);
        _towers.Add(tower);
    }

    
    private void RemoveTower(Collider2D other)
    {
        var tower = other.GetComponentInParent<Tower>();
        tower.ChangeDamageCoefficient(1/_totalDamageCoefficientBuff);
        _towers.Remove(tower);
    }

    private void CalculateTotalCoefficients(int currentUpgradeLevel)
    {
        _totalDamageCoefficientBuff *= _voidTowerBuffAbilityLevelData.DamageCoefficientBuff[currentUpgradeLevel];
        
        foreach (var tower in _towers)
        {
            tower.ChangeDamageCoefficient(_voidTowerBuffAbilityLevelData.DamageCoefficientBuff[currentUpgradeLevel]);
        }
    }
}
