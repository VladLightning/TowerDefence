
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/Special/ArrowRain", order = 2)]
public class ArrowRainData : ScriptableObject
{
    [SerializeField] private DamageTypesEnum _damageType;
    public DamageTypesEnum DamageType => _damageType;
    [SerializeField] private float _animationInterval;
    public float AnimationInterval => _animationInterval;
    [SerializeField] private int _arrowsAmount;
    public int ArrowsAmount => _arrowsAmount;
    [SerializeField] private int _damagePerArrow;
    public int DamagePerArrow => _damagePerArrow;
    [SerializeField] private float _areaRadius;
    public float AreaRadius => _areaRadius;
}
