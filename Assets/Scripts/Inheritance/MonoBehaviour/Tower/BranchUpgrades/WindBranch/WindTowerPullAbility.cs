
using System.Collections;
using UnityEngine;

public class WindTowerPullAbility : UpgradeableBranchAbility
{
    private readonly float _maxForceAtDistanceFraction = 0.25f;
    
    private WindTowerPullAbilityLevelData _windTowerPullAbilityLevelData;

    private Tower _tower;
    
    private float _force;
    private float _interval;
    
    private bool _pullIsActive;
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _windTowerPullAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as WindTowerPullAbilityLevelData;
        _force = _windTowerPullAbilityLevelData.PullStats[0].PullForce;
        _interval = _windTowerPullAbilityLevelData.PullStats[0].PullInterval;
    }

    public override void Upgrade(int levelIndex)
    {
        _force = _windTowerPullAbilityLevelData.PullStats[levelIndex].PullForce;
        _interval = _windTowerPullAbilityLevelData.PullStats[levelIndex].PullInterval;
    }

    private void Start()
    {
        _tower = GetComponent<Tower>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !_pullIsActive)
        {
            StartCoroutine(WindTowerPull());
        }
    }

    private IEnumerator WindTowerPull()
    {
        _pullIsActive = true;
        while (_tower.Target != null)
        {
            yield return new WaitForSeconds(_interval);
            if (_tower.Target == null)
            {
                _pullIsActive = false;
                yield break;
            }
            Pull();
        }
        
        _pullIsActive = false;
    }

    private void Pull()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _tower.Range, LayerMask.GetMask("Enemy"));

        foreach (var collider in colliders)
        {
            var direction = transform.position - collider.transform.position;
            direction.Normalize();
            collider.attachedRigidbody.AddForce(direction * _force * CalculatePullForceCoefficient(collider.transform));
        }
    }

    private float CalculatePullForceCoefficient(Transform target)
    {
        var distanceToTower = Vector3.Distance(transform.position, target.position);
        if (distanceToTower > _tower.Range * _maxForceAtDistanceFraction)
        {
            return (_tower.Range - distanceToTower)/_tower.Range;
        }

        return 1;
    }
}
