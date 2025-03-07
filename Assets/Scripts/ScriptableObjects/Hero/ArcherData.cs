using UnityEngine;
[CreateAssetMenu(fileName = "HeroData", menuName = "Hero/Archer")]
public class ArcherData : HeroData
{
    [SerializeField] private Sprite _rangedWeapon;
    public Sprite RangedWeapon => _rangedWeapon;
    
    [SerializeField] private Sprite _meleeWeapon;
    public Sprite MeleeWeapon => _meleeWeapon;
    
    [SerializeField] private DefaultProjectileData _projectileData;
    public DefaultProjectileData ProjectileData => _projectileData;
}
