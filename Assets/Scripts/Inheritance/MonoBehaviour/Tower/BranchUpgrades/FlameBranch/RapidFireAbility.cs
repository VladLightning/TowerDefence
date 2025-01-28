
using System.Collections;
using UnityEngine;

public class RapidFireAbility : BranchAbility
{
    private RapidFireAbilityLevelData _rapidFireAbilityLevelData;
    private Tower _tower;
    
    private int _currentCapacity;
    private int _currentAvailableShots;
    
    private float _currentRapidShotInterval;

    private float _currentRapidShotLoadTime;

    private void Start()
    {
        StartCoroutine(LoadRapidFireShots());
    }

    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _rapidFireAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as RapidFireAbilityLevelData;
        
        _currentCapacity = _rapidFireAbilityLevelData.RapidFireStats[0].Capacity;
        _currentRapidShotInterval = _rapidFireAbilityLevelData.RapidFireStats[0].RapidShotInterval;
        _currentRapidShotLoadTime = _rapidFireAbilityLevelData.RapidFireStats[0].RapidShotLoadTime;
        
        _tower = GetComponent<Tower>();
    }
    
    public IEnumerator LoadRapidFireShots()
    {
        while (_currentAvailableShots < _currentCapacity && !_tower.ShootingIsActive)
        {
            yield return new WaitForSeconds(_currentRapidShotLoadTime);
            _currentAvailableShots++;
        }
    }
    
    public IEnumerator RapidFire()
    {
        while(_currentAvailableShots > 0)
        {
            yield return new WaitForSeconds(_currentRapidShotInterval);
            _currentAvailableShots--;
            _tower.SpawnProjectile();
        }
    }
}
