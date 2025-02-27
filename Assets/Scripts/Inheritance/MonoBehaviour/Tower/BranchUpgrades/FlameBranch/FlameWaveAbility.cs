using System.Collections;
using UnityEngine;

public class FlameWaveAbility : DamageDealingBranchAbility
{
    private GameObject _flameWavePrefab;
    
    private FlameWaveAbilityLevelData _flameWaveAbilityLevelData;
    private Tower _tower;

    private float _flameWaveReloadTime;
    private float _flameWaveDuration;
    private float _flameWaveSpeed;
    
    private IEnumerator _flameWave;
    private TowerAbilitiesStates.TowerAbilityStates _abilityState;
    
    private float _lastShotTime;
    
    private void Update()
    {
        TargetCheck();
    }

    private void TargetCheck()
    {
        if (_tower.Target is not null && _abilityState == TowerAbilitiesStates.TowerAbilityStates.Inactive)
        {
            _abilityState = TowerAbilitiesStates.TowerAbilityStates.Active;
            
            float delay = (Time.time - _lastShotTime > _flameWaveReloadTime) ? Tower.DELAY_FOR_ROTATION : _flameWaveReloadTime - (Time.time - _lastShotTime);
            _flameWave = FlameWave(delay);
            
            StartCoroutine(_flameWave);
        }
        else if (_tower.Target is null && _abilityState == TowerAbilitiesStates.TowerAbilityStates.Active)
        {
            _abilityState = TowerAbilitiesStates.TowerAbilityStates.Inactive;
            StopCoroutine(_flameWave);
        }
    }

    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _flameWaveAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as FlameWaveAbilityLevelData;
        
        _flameWavePrefab = _flameWaveAbilityLevelData.FlameWavePrefab;
        _damageType = _flameWaveAbilityLevelData.DamageType;

        _flameWaveReloadTime = _flameWaveAbilityLevelData.FlameWaveLevels[0].FlameWaveReloadTime;
        _flameWaveDuration = _flameWaveAbilityLevelData.FlameWaveLevels[0].FlameWaveDuration;
        _flameWaveSpeed = _flameWaveAbilityLevelData.FlameWaveLevels[0].FlameWaveSpeed;
        _damage = _flameWaveAbilityLevelData.FlameWaveLevels[0].FlameWaveDamage;
        
        _tower = GetComponent<Tower>();
    }

    public override void Upgrade(int levelIndex)
    {
        _flameWaveReloadTime = _flameWaveAbilityLevelData.FlameWaveLevels[levelIndex].FlameWaveReloadTime;
        _flameWaveDuration = _flameWaveAbilityLevelData.FlameWaveLevels[levelIndex].FlameWaveDuration;
        _flameWaveSpeed = _flameWaveAbilityLevelData.FlameWaveLevels[levelIndex].FlameWaveSpeed;
        _damage = _flameWaveAbilityLevelData.FlameWaveLevels[levelIndex].FlameWaveDamage;
    }

    private IEnumerator FlameWave(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            
            var flameWave = Instantiate(_flameWavePrefab, _tower.ProjectileLaunchPoint.position, _tower.ProjectileLaunchPoint.rotation).GetComponent<FlameWave>();
            flameWave.Initialize(_flameWaveDuration, _flameWaveSpeed, _damage, _damageType);

            _lastShotTime = Time.time;
            delay = _flameWaveReloadTime;
        }
    }
}
