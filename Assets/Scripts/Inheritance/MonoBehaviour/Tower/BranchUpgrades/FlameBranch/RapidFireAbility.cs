
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

    private IEnumerator _specialReload;
    private IEnumerator _specialShooting;

    private bool _isReloading;

    private void Start()
    {
        _specialReload = SpecialReload();
        _specialShooting = SpecialShooting();
    }

    private void Update()
    {
        if (_tower.Target is not null)
        {
            Debug.Log(1);
            if (_isReloading)
            {
                _specialShooting = SpecialShooting();
                Debug.Log(2);
                StopCoroutine(_specialReload);
                StartCoroutine(_specialShooting);
                _isReloading = false;
            }
        }
        else
        {
            Debug.Log(3);
            if (!_isReloading)
            {
                _specialReload = SpecialReload();
                Debug.Log(4);
                StopCoroutine(_specialShooting);
                StartCoroutine(_specialReload);
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

    public IEnumerator SpecialReload()
    {
        while (_currentAvailableShots < _currentCapacity)
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
