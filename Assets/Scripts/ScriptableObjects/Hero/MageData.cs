
using UnityEngine;
[CreateAssetMenu(fileName = "HeroData", menuName = "Hero/Mage")]
public class MageData : HeroData
{
    [SerializeField] private StatusProjectileData _projectileData;
    public StatusProjectileData ProjectileData => _projectileData;
}
