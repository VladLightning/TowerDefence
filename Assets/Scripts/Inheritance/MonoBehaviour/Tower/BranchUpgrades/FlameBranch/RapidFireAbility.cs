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

    private TowerAbilitiesStates.TowerAbilityStates _abilityState;

    private void Start()
    {
        _rapidShotsReload = RapidShotsReload();
        _rapidFire = RapidFire();
    }

    private void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
        if (_tower.Target is not null && _abilityState == TowerAbilitiesStates.TowerAbilityStates.Active)
        {
            _rapidFire = RapidFire();
            StopCoroutine(_rapidShotsReload);
            StartCoroutine(_rapidFire);
            _abilityState = TowerAbilitiesStates.TowerAbilityStates.Inactive;     
        }
        else if (_tower.Target is null && _abilityState == TowerAbilitiesStates.TowerAbilityStates.Inactive)
        {
            _rapidShotsReload = RapidShotsReload();
            StopCoroutine(_rapidFire);
            StartCoroutine(_rapidShotsReload);
            _abilityState = TowerAbilitiesStates.TowerAbilityStates.Active;
        }
    }

    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _rapidFireAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as RapidFireAbilityLevelData;
        
        _currentCapacity = _rapidFireAbilityLevelData.RapidFireLevels[0].RapidShotsCapacity;
        _currentRapidShotInterval = _rapidFireAbilityLevelData.RapidFireLevels[0].RapidShotInterval;
        _currentRapidShotLoadTime = _rapidFireAbilityLevelData.RapidFireLevels[0].RapidShotLoadTime;
        
        _tower = GetComponent<Tower>();
    }

    public override void Upgrade(int levelIndex)
    {
        _currentCapacity = _rapidFireAbilityLevelData.RapidFireLevels[levelIndex].RapidShotsCapacity;
        _currentRapidShotInterval = _rapidFireAbilityLevelData.RapidFireLevels[levelIndex].RapidShotInterval;
        _currentRapidShotLoadTime = _rapidFireAbilityLevelData.RapidFireLevels[levelIndex].RapidShotLoadTime;
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
