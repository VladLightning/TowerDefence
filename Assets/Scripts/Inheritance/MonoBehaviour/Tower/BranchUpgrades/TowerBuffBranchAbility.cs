

using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBuffBranchAbility : UpgradeableBranchAbility
{
    protected readonly List<Tower> _towers = new List<Tower>();
    private Tower _towerSelf;
    
    protected abstract void ApplyBuff(Tower tower);
    protected abstract void RemoveBuff(Tower tower);

    protected abstract void CalculateTotalCoefficients(int currentUpgradeLevel);

    public abstract override void Initiate(BranchUpgradeData branchUpgradeData);

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
        ApplyBuff(tower);
        _towers.Add(tower);
    }
    
    private void RemoveTower(Collider2D other)
    {
        var tower = other.GetComponentInParent<Tower>();
        RemoveBuff(tower);
        _towers.Remove(tower);
    }
}
