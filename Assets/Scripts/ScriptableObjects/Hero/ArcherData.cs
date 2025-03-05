using UnityEngine;
[CreateAssetMenu(fileName = "HeroData", menuName = "Hero/Archer")]
public class ArcherData : HeroData
{
    [SerializeField] private GameObject _rangedWeapon;
    public GameObject RangedWeapon => _rangedWeapon;
    
    [SerializeField] private GameObject _meleeWeapon;
    public GameObject MeleeWeapon => _meleeWeapon;
    
    [SerializeField] private DefaultProjectileData _projectileData;
    public DefaultProjectileData ProjectileData => _projectileData;
}
