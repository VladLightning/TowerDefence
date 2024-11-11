using DG.Tweening;
using UnityEngine;
public class HeroSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _heroToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private MouseInput _mouseInput;

    [SerializeField] private HeroData[] _heroData;

    [SerializeField] private AbilityDisplay[] _abilityDisplays;
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    
    [SerializeField] private Path[] _enemyPaths;
    [SerializeField] private TweenAnimation _animator;

    private void Start()
    {
        SpawnHero();
    }

    private void SpawnHero()
    {
        GameObject hero = Instantiate(_heroToSpawn, _spawnPoint.position, _spawnPoint.rotation);
        hero.GetComponent<Hero>().Initiate(_heroData[0]);
        _mouseInput.Hero = hero.GetComponent<Hero>();

        var abilities = hero.GetComponents<Ability>();
        for (int i = 0; i < _abilityDisplays.Length; i++)
        {
            abilities[i].AbilityDisplay = _abilityDisplays[i];
        }
        _playerInputHandler.InitPlayerAbilities(abilities);
        hero.GetComponent<DefaultAbility>().InitDefaultAbility(_enemyPaths[0].PathPoints[^1], _animator);
    }
}
