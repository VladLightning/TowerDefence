
using UnityEngine;
public class HeroRadiusBuff : MonoBehaviour, IPassiveHeroSkillDeactivatable
{
    [SerializeField] private HeroRadiusBuffData _heroRadiusBuffData;

    private float _damageBuffCoefficient;
    private float _attackDelayBuffCoefficient;
    private float _buffRadius;

    private Tower _towerToBuff;

    private void Start()
    {
        _damageBuffCoefficient = _heroRadiusBuffData.DamageBuffCoefficient;
        _attackDelayBuffCoefficient = _heroRadiusBuffData.AttackDelayBuffCoefficient;
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
        _towerToBuff.ChangeAttackDelayCoefficient(_attackDelayBuffCoefficient);
    }

    public void Deactivate()
    {
        _towerToBuff.ChangeDamageCoefficient(1/_damageBuffCoefficient);
        _towerToBuff.ChangeAttackDelayCoefficient(1/_attackDelayBuffCoefficient);
    }
}
