using UnityEngine;
using System;
public class HeroSpawner : MonoBehaviour
{
    public static event Action<Ability[]> OnAbilitiesSpawned;
    
    [SerializeField] private GameObject _heroToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private MouseInput _mouseInput;

    [SerializeField] private HeroData[] _heroData;
    [SerializeField] private GameObject[] _heroAbilities;

    [SerializeField] private AbilityDisplay[] _abilityDisplays;

    private void Start()
    {
        SpawnHero();
    }

    private void SpawnHero()
    {
        var hero = Instantiate(_heroToSpawn, _spawnPoint.position, _spawnPoint.rotation);
        hero.GetComponent<Hero>().Initiate(_heroData[0]);
        _mouseInput.Hero = hero.GetComponent<Hero>();
        
        var abilities = new Ability[_abilityDisplays.Length];
        for (int i = 0; i < _abilityDisplays.Length; i++)
        {
            abilities[i] = Instantiate(_heroAbilities[i], hero.transform).GetComponent<Ability>();
            abilities[i].AbilityDisplay = _abilityDisplays[i];
        }
        OnAbilitiesSpawned?.Invoke(abilities);
    }
}
