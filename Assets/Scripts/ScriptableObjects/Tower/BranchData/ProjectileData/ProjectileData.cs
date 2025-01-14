using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile", order = 1)]
public class ProjectileData : ScriptableObject
{
    [SerializeField] private GameObject _projectilePrefab;
    public GameObject ProjectilePrefab => _projectilePrefab;
    
    [SerializeField] private ProjectileStats[] _projectileLevels;
    public ProjectileStats[] ProjectileLevels => _projectileLevels;
}

[System.Serializable]
public class ProjectileStats
{
    [SerializeField] private int _damage;
    public int Damage => _damage;
    
    [SerializeField] private float _force;
    public float Force => _force;
}