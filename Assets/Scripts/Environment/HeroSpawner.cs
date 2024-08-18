using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _heroToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private HeroPath _movementPath;
    [SerializeField] private Camera _gameCamera;

    [SerializeField] private HeroData[] _heroData;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject hero = Instantiate(_heroToSpawn, _spawnPoint.position, _spawnPoint.rotation);
        hero.GetComponent<Hero>().Initiate(_heroData[0], _gameCamera);
        _movementPath.Hero = hero.GetComponent<Hero>();
    }
}
