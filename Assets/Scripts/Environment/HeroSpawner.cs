using UnityEngine;
public class HeroSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _heroToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private MouseInput _mouseHeroMovement;

    [SerializeField] private HeroData[] _heroData;

    private void Start()
    {
        SpawnHero();
    }

    private void SpawnHero()
    {
        GameObject hero = Instantiate(_heroToSpawn, _spawnPoint.position, _spawnPoint.rotation);
        hero.GetComponent<Hero>().Initiate(_heroData[0]);
        _mouseHeroMovement.Hero = hero.GetComponent<Hero>();
    }
}
