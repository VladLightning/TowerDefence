
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

    private IEnumerator _specialReload;
    private IEnumerator _specialShooting;

    private void Start()
    {
        _specialReload = SpecialReload();
        _specialShooting = SpecialShooting();
        StartCoroutine(_specialReload);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !_tower.ShootingIsActive)
        {
            StopCoroutine(_specialReload);
            StartCoroutine(_specialShooting);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == _tower.Target)
        {
            StopCoroutine(_specialShooting);
            StartCoroutine(_specialReload);
        }
    }

    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _rapidFireAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as RapidFireAbilityLevelData;
        
        _currentCapacity = _rapidFireAbilityLevelData.SpecialShootingStats[0].SpecialShotsCapacity;
        _currentRapidShotInterval = _rapidFireAbilityLevelData.SpecialShootingStats[0].SpecialShotInterval;
        _currentRapidShotLoadTime = _rapidFireAbilityLevelData.SpecialShootingStats[0].SpecialShotLoadTime;
        
        _tower = GetComponent<Tower>();
    }
    
    public IEnumerator SpecialReload()
    {
        while (_currentAvailableShots < _currentCapacity && !_tower.ShootingIsActive)
        {
            yield return new WaitForSeconds(_currentRapidShotLoadTime);
            _currentAvailableShots++;
        }
    }
    
    public IEnumerator SpecialShooting()
    {
        while(_currentAvailableShots > 0)
        {
            yield return new WaitForSeconds(_currentRapidShotInterval);
            _currentAvailableShots--;
            _tower.SpawnProjectile();
        }
    }
}
