
using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class ElementalAbsorption : MonoBehaviour, IPassiveHeroSkillDeactivatable
{
    [SerializeField] private Transform _projectileLaunchPoint;
    
    [SerializeField] private ElementalAbsorptionData _elementalAbsorptionData;
    
    private RangedHeroDetectShootingTarget _rangedHeroDetectShootingTarget;

    private SerializedDictionary<DamageTypesEnum.DamageTypes, GameObject> _elementalProjectiles = new();
    private SerializedDictionary<DamageTypesEnum.DamageTypes, StatusProjectileStats> _projectilesStats = new();
    
    private SerializedDictionary<DamageTypesEnum.DamageTypes, float> _elementalResistancesCoefficients = new();

    private float _attackDelay;
    
    private RangedHero _rangedHero;
    
    private DamageTypesEnum.DamageTypes _currentAbsorbedType;

    private IEnumerator _absorptionShooting;

    private bool _absorptionShootingIsActive;

    private void Start()
    {
        foreach (var projectileType in _elementalAbsorptionData.ElementalProjectiles)
        {
            _elementalProjectiles.Add(projectileType.Key, projectileType.Value);
        }
        foreach (var projectileStats in _elementalAbsorptionData.ProjectilesStats)
        {
            _projectilesStats.Add(projectileStats.Key, projectileStats.Value);
        }
        foreach (var resistanceType in _elementalAbsorptionData.ElementalResistancesCoefficients)
        {
            _elementalResistancesCoefficients.Add(resistanceType.Key, resistanceType.Value);
        }

        _attackDelay = _elementalAbsorptionData.AbsorbedElementAttackDelay;

        _rangedHeroDetectShootingTarget = GetComponent<RangedHeroDetectShootingTarget>();
        _rangedHero = GetComponentInParent<RangedHero>();
        
        IncreaseDefaultResistance();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TowerBody"))
        {
            var tower = other.GetComponentInParent<Tower>();
            
            if (tower.StatusProjectileData == null)
            {
                return;
            }
            
            _currentAbsorbedType = tower.StatusProjectileData.DamageType;
            Activate();
        }
        if(other.CompareTag("Enemy") && _currentAbsorbedType != DamageTypesEnum.DamageTypes.Physical)
        {
            EnableAbsorptionShooting();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TowerBody"))
        {
            if (_currentAbsorbedType == DamageTypesEnum.DamageTypes.Physical)
            {
                return;
            }
            Deactivate();
        }
        if(other.CompareTag("Enemy") && _currentAbsorbedType != DamageTypesEnum.DamageTypes.Physical)
        {
            DisableAbsorptionShooting();
        }
    }

    private IEnumerator AbsorptionShooting(DamageTypesEnum.DamageTypes damageType)
    {
        _absorptionShootingIsActive = true;
        while (_rangedHeroDetectShootingTarget.TargetToShoot != null)
        {
            yield return new WaitForSeconds(_attackDelay);
            var projectile = Instantiate(_elementalProjectiles[damageType], _projectileLaunchPoint.position, _rangedHero.CalculateProjectileDirection()).GetComponent<StatusProjectile>();
            projectile.Initialize(_projectilesStats[damageType],default,_currentAbsorbedType);
        }
        _absorptionShootingIsActive = false;
    }

    private void EnableAbsorptionShooting()
    {
        if (_absorptionShootingIsActive)
        {
            return;
        }
        
        _absorptionShooting = AbsorptionShooting(_currentAbsorbedType);
        StartCoroutine(_absorptionShooting);
    }

    private void DisableAbsorptionShooting()
    {
        if (_absorptionShooting != null)
        {
            StopCoroutine(_absorptionShooting);
        }
    }

    private void IncreaseDefaultResistance()
    {
        _rangedHero.IncreaseDamageResistance(_elementalResistancesCoefficients[_rangedHero.DamageType], _rangedHero.DamageType);
    }

    private void DecreaseDefaultResistance()
    {
        _rangedHero.DecreaseDamageResistance(_elementalResistancesCoefficients[_rangedHero.DamageType], _rangedHero.DamageType);
    }

    public void Activate()
    {
        DecreaseDefaultResistance();

        _rangedHero.IncreaseDamageResistance(_elementalResistancesCoefficients[_currentAbsorbedType], _currentAbsorbedType);
    }

    public void Deactivate()
    {
        _rangedHero.DecreaseDamageResistance(_elementalResistancesCoefficients[_currentAbsorbedType], _currentAbsorbedType);
        
        IncreaseDefaultResistance();
    }
}
