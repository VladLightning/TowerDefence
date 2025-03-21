
using System.Collections;
using UnityEngine;

public class ArrowRainSkill : MonoBehaviour, IActiveHeroSkill
{
    [SerializeField] private ArrowRainSkillData _arrowRainSkillData;

    private GameObject _arrowRainPrefab;
    
    private float _cooldown;
    private ArrowRainData _arrowRainData;
    
    private RangedHeroDetectShootingTarget _rangedHeroDetectShootingTarget;
    
    private bool _arrowRainIsActive;

    private void Start()
    {
        _arrowRainPrefab = _arrowRainSkillData.ArrowRainPrefab;
        
        _cooldown = _arrowRainSkillData.Cooldown;
        _arrowRainData = _arrowRainSkillData.ArrowRainData;
        
        _rangedHeroDetectShootingTarget = GetComponent<RangedHeroDetectShootingTarget>();
    }

    public void ActiveSkillTrigger()
    {
        if (!_arrowRainIsActive)
        {
            StartCoroutine(SpawnArrowRain());
        }
    }

    private IEnumerator SpawnArrowRain()
    {
        _arrowRainIsActive = true; 
        var arrowRain = Instantiate(_arrowRainPrefab, _rangedHeroDetectShootingTarget.TargetToShoot.transform.position, _arrowRainPrefab.transform.rotation).GetComponent<ArrowRain>();
        arrowRain.Initiate(_arrowRainData);
        yield return new WaitForSeconds(_cooldown);
        _arrowRainIsActive = false;
    }
}
