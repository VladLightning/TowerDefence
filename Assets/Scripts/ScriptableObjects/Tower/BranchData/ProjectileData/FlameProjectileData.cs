
using UnityEngine;

[CreateAssetMenu(fileName = "FlameProjectileData", menuName = "ProjectileData/FlameProjectile", order = 2)]
public class FlameProjectileData : ProjectileData
{
    [SerializeField]  private int _burningDamage;
    public int BurningDamage => _burningDamage;

    [SerializeField] private int _burningInterval;
    public int BurningInterval => _burningInterval;
}