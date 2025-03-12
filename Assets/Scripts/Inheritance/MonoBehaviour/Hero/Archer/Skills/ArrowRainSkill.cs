
using System.Collections;
using UnityEngine;

public class ArrowRainSkill : MonoBehaviour, IActiveHeroSkill
{
    [SerializeField] private ArrowRainSkillData _arrowRainSkillData;

    private GameObject _arrowRainPrefab;
    
    private float _cooldown;
    private ArrowRainData _arrowRainData;
    
    private Archer _archer;
    private ArcherDetectShootingTarget _archerDetectShootingTarget;
    
    private bool _arrowRainIsActive;

    private void Start()
    {
        _arrowRainPrefab = _arrowRainSkillData.ArrowRainPrefab;
        
        _cooldown = _arrowRainSkillData.Cooldown;
        _arrowRainData = _arrowRainSkillData.ArrowRainData;
        
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
            var arrowRain = Instantiate(_arrowRainPrefab, _archerDetectShootingTarget.TargetToShoot.transform.position, _arrowRainPrefab.transform.rotation).GetComponent<ArrowRain>();
            arrowRain.Initiate(_arrowRainData);
        }
        _arrowRainIsActive = false;
    }
}
