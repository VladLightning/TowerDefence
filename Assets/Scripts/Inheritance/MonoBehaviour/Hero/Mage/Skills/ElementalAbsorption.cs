
using UnityEngine;

public class ElementalAbsorption : MonoBehaviour, IPassiveHeroSkillDeactivatable
{
    [SerializeField] private Transform _projectileLaunchPoint;
    
    [SerializeField] private ElementalAbsorptionData _elementalAbsorptionData;
    
    private LayerMask _layerMask;
    private float _radius;
    
    private Tower _closestTower;
    
    private RangedHero _rangedHero;
    
    private DamageTypesEnum.DamageTypes _currentAbsorbedType;

    private void Start()
    {
        _layerMask = _elementalAbsorptionData.LayerMask;
        _radius = _elementalAbsorptionData.Radius;
        
        _rangedHero = GetComponentInParent<RangedHero>();
        
        IncreaseResistance(_rangedHero.DamageType);
    }
    
    public void Activate()
    {
        AbsorptionShooting();
    }

    public void Deactivate()
    {
        if (_currentAbsorbedType == DamageTypesEnum.DamageTypes.Physical)
        {
            return;
        }
        DecreaseResistance(_currentAbsorbedType);
        
        IncreaseResistance(_rangedHero.DamageType);
    }
    
    private void ActivateResistanceIncrease()
    {
        if (_currentAbsorbedType == DamageTypesEnum.DamageTypes.Physical)
        {
            return;
        }
        DecreaseResistance(_rangedHero.DamageType);

        IncreaseResistance(_currentAbsorbedType);
    }

    private void AbsorptionShooting()
    {
        AbsorbClosestTowerElement();

        if (_currentAbsorbedType == DamageTypesEnum.DamageTypes.Physical)
        {
            return;
        }
        
        var projectile = Instantiate(_elementalAbsorptionData.ElementalProjectiles[_currentAbsorbedType], _projectileLaunchPoint.position, 
            _rangedHero.CalculateProjectileDirection()).GetComponent<StatusProjectile>();
        projectile.Initialize(_elementalAbsorptionData.ProjectilesStats[_currentAbsorbedType], damageType: _currentAbsorbedType);
    }

    private void AbsorbClosestTowerElement()
    {
        var towers = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
        
        if(towers.Length == 0)
        {
            _closestTower = null;
            Deactivate();
            _currentAbsorbedType = DamageTypesEnum.DamageTypes.Physical;
            return;
        }

        float shortestDistance = Vector2.Distance(towers[0].transform.position, transform.position);
        var possibleClosestTower = towers[0];

        for (int i = 1; i < towers.Length; i++)
        {          
            float newDistance = Vector2.Distance(towers[i].transform.position, transform.position);
            if (shortestDistance > newDistance)
            {
                shortestDistance = newDistance;
                possibleClosestTower = towers[i];
            }
        }

        var closestTower = possibleClosestTower.GetComponentInParent<Tower>();

        if (closestTower == _closestTower)
        {
            return;
        }
        
        Deactivate();
            
        if (closestTower.DamageType == DamageTypesEnum.DamageTypes.Physical)
        {
            return;
        }
            
        _closestTower = closestTower;
        _currentAbsorbedType = _closestTower.DamageType;
            
        ActivateResistanceIncrease();
    }
    
    private void IncreaseResistance(DamageTypesEnum.DamageTypes damageType)
    {
        _rangedHero.IncreaseDamageResistance(_elementalAbsorptionData.ElementalResistancesCoefficients[damageType], damageType);
    }

    private void DecreaseResistance(DamageTypesEnum.DamageTypes damageType)
    {
        _rangedHero.DecreaseDamageResistance(_elementalAbsorptionData.ElementalResistancesCoefficients[damageType], damageType);
    }
}
