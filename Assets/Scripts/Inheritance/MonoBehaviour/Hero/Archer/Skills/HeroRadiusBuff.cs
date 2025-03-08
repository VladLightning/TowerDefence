
using UnityEngine;
public class HeroRadiusBuff : MonoBehaviour, IPassiveHeroSkillDeactivatable
{
    [SerializeField] private HeroRadiusBuffData _heroRadiusBuffData;

    private float _damageBuffCoefficient;
    private float _attackSpeedBuffCoefficient;
    private float _buffRadius;

    private Tower _towerToBuff;

    private void Start()
    {
        _damageBuffCoefficient = _heroRadiusBuffData.DamageBuffCoefficient;
        _attackSpeedBuffCoefficient = _heroRadiusBuffData.AttackSpeedBuffCoefficient;
        _buffRadius = _heroRadiusBuffData.BuffRadius;
        
        GetComponent<CircleCollider2D>().radius = _buffRadius;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("TowerBody"))
        {
            _towerToBuff = other.GetComponentInParent<Tower>();
            Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("TowerBody"))
        {
            _towerToBuff = other.GetComponentInParent<Tower>();
            Deactivate();
        }
    }

    public void Activate()
    {
        _towerToBuff.ChangeDamageCoefficient(_damageBuffCoefficient);
        _towerToBuff.ChangeAttackSpeedCoefficient(_attackSpeedBuffCoefficient);
    }

    public void Deactivate()
    {
        _towerToBuff.ChangeDamageCoefficient(1/_damageBuffCoefficient);
        _towerToBuff.ChangeAttackSpeedCoefficient(1/_attackSpeedBuffCoefficient);
    }
}
