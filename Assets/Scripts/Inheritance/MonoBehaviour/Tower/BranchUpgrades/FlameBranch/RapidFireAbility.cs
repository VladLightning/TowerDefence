using System.Collections;
using UnityEngine;

public class RapidFireAbility : UpgradeableBranchAbility
{
    private RapidFireAbilityLevelData _rapidFireAbilityLevelData;
    private Tower _tower;
    
    private int _currentCapacity;
    private int _currentAvailableShots;
    
    private float _currentRapidShotInterval;

    private float _currentRapidShotLoadTime;

    private IEnumerator _rapidShotsReload;
    private IEnumerator _rapidFire;

    private bool _isReloading;

    private void Start()
    {
        _rapidShotsReload = RapidShotsReload();
        _rapidFire = RapidFire();
    }

    private void Update()
    {
        if (_tower.Target is not null)
        {
            if (_isReloading)
            {
                _rapidFire = RapidFire();
                StopCoroutine(_rapidShotsReload);
                StartCoroutine(_rapidFire);
                _isReloading = false;
            }
        }
        else
        {
            if (!_isReloading)
            {
                _rapidShotsReload = RapidShotsReload();
                StopCoroutine(_rapidFire);
                StartCoroutine(_rapidShotsReload);
                _isReloading = true;
            }
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

    public override void Upgrade(int levelIndex)
    {
        _currentCapacity = _rapidFireAbilityLevelData.SpecialShootingStats[levelIndex].SpecialShotsCapacity;
        _currentRapidShotInterval = _rapidFireAbilityLevelData.SpecialShootingStats[levelIndex].SpecialShotInterval;
        _currentRapidShotLoadTime = _rapidFireAbilityLevelData.SpecialShootingStats[levelIndex].SpecialShotLoadTime;
    }

    private IEnumerator RapidShotsReload()
    {
        while (_currentAvailableShots < _currentCapacity)
        {
            yield return new WaitForSeconds(_currentRapidShotLoadTime);
            _currentAvailableShots++;
        }
    }
    
    private IEnumerator RapidFire()
    {
        while(_currentAvailableShots > 0)
        {
            yield return new WaitForSeconds(_currentRapidShotInterval);
            _currentAvailableShots--;
            _tower.SpawnProjectile();
        }
    }
}
