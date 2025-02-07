using System;
using System.Collections;
using UnityEngine;

public class FrostWaveAbility : UpgradeableBranchAbility
{
    private GameObject _frostWavePrefab;
    
    private FrostWaveAbilityLevelData _frostWaveAbilityLevelData;
    private Tower _tower;
    
    private float _frostWaveRadius;
    private float _frostWaveSpeedReduction;
    private float _frostWaveSpeedReductionDuration;
    private float _frostWaveInterval;
    private float _frostWaveDuration;
    
    private IEnumerator _frostWave;
    private TowerAbilitiesStates.TowerAbilityStates _abilityState;

    private void Start()
    {
        _frostWave = FrostWave();
    }

    private void Update()
    {
        TargetCheck();
    }

    private void TargetCheck()
    {
        if (_tower.Target is not null && _abilityState == TowerAbilitiesStates.TowerAbilityStates.Inactive)
        {
            _abilityState = TowerAbilitiesStates.TowerAbilityStates.Active;
            StartCoroutine(_frostWave);
        }
        else if (_tower.Target is null && _abilityState == TowerAbilitiesStates.TowerAbilityStates.Active)
        {
            _abilityState = TowerAbilitiesStates.TowerAbilityStates.Inactive;
            StopCoroutine(_frostWave);
        }
    }

    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _frostWaveAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as FrostWaveAbilityLevelData;

        _frostWavePrefab = _frostWaveAbilityLevelData.FrostWavePrefab;
        
        _frostWaveRadius = _frostWaveAbilityLevelData.FrostWaveLevels[0].FrostWaveRadius;
        _frostWaveSpeedReduction = _frostWaveAbilityLevelData.FrostWaveLevels[0].FrostWaveSpeedReduction;
        _frostWaveSpeedReductionDuration = _frostWaveAbilityLevelData.FrostWaveLevels[0].FrostWaveSpeedReductionDuration;
        _frostWaveInterval = _frostWaveAbilityLevelData.FrostWaveLevels[0].FrostWaveInterval;
        _frostWaveDuration = _frostWaveAbilityLevelData.FrostWaveLevels[0].FrostWaveDuration;
        
        _tower = GetComponent<Tower>();
    }

    public override void Upgrade(int levelIndex)
    {
        _frostWaveRadius = _frostWaveAbilityLevelData.FrostWaveLevels[levelIndex].FrostWaveRadius;
        _frostWaveSpeedReduction = _frostWaveAbilityLevelData.FrostWaveLevels[levelIndex].FrostWaveSpeedReduction;
        _frostWaveSpeedReductionDuration = _frostWaveAbilityLevelData.FrostWaveLevels[levelIndex].FrostWaveSpeedReductionDuration;
        _frostWaveInterval = _frostWaveAbilityLevelData.FrostWaveLevels[levelIndex].FrostWaveInterval;
        _frostWaveDuration = _frostWaveAbilityLevelData.FrostWaveLevels[levelIndex].FrostWaveDuration;
    }

    private IEnumerator FrostWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(_frostWaveInterval);
            
            var frostWave = Instantiate(_frostWavePrefab, transform.position, transform.rotation).GetComponent<FrostWave>();
            frostWave.Initialize(_frostWaveSpeedReduction, _frostWaveSpeedReductionDuration,_frostWaveRadius, _frostWaveDuration);
        }
    }
    
}
