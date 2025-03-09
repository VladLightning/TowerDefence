
using System.Collections;
using UnityEngine;

public class ArrowRain : MonoBehaviour, IActiveHeroSkill
{
    [SerializeField] private ArrowRainData _arrowRainData;

    private GameObject _arrowRainPrefab;
    
    private float _damage;
    private float _cooldown;
    private float _areaRadius;
    
    private Archer _archer;
    private ArcherDetectShootingTarget _archerDetectShootingTarget;
    
    private bool _arrowRainIsActive;

    private void Start()
    {
        _arrowRainPrefab = _arrowRainData.ArrowRainPrefab;
        
        _damage = _arrowRainData.Damage;
        _cooldown = _arrowRainData.Cooldown;
        _areaRadius = _arrowRainData.AreaRadius;
        
        _archer = GetComponentInParent<Archer>();
        _archerDetectShootingTarget = GetComponent<ArcherDetectShootingTarget>();
    }

    public void ActiveSkillTrigger()
    {
        if (_archer.ShootingIsActive && !_arrowRainIsActive)
        {
            StartCoroutine(SpawnArrowRain());
        }
    }

    private IEnumerator SpawnArrowRain()
    {
        _arrowRainIsActive = true;
        while (_archerDetectShootingTarget.TargetToShoot != null)
        {
            yield return new WaitForSeconds(_cooldown);
            if (_archerDetectShootingTarget.TargetToShoot == null)
            {
                _arrowRainIsActive = false;
                yield break;
            }
            var arrowRain = Instantiate(_arrowRainPrefab, _archerDetectShootingTarget.TargetToShoot.transform.position, _arrowRainPrefab.transform.rotation);
        }
        _arrowRainIsActive = false;
    }
}
