using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile", order = 1)]
public class ProjectileData : ScriptableObject
{
    [SerializeField] private GameObject _projectilePrefab;
    public GameObject ProjectilePrefab => _projectilePrefab;
    
    [SerializeField] private ProjectileLevels[] _projectileLevels;
    public ProjectileLevels[] ProjectileLevels => _projectileLevels;
}

[System.Serializable]
public class ProjectileLevels
{
    [SerializeField] private int _damage;
    public int Damage => _damage;
    
    [SerializeField] private float _force;
    public float Force => _force;
}