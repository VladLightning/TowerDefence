
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class VoidTowerResistanceShredAbility : UpgradeableBranchAbility
{
    private readonly List<Enemy> _enemies = new List<Enemy>();
    private Tower _tower;

    private VoidTowerResistanceShredAbilityLevelData _voidTowerResistanceShredAbilityLevelData;
    
    private SerializedDictionary<DamageTypesEnum, float> _resistanceShreds = new SerializedDictionary<DamageTypesEnum, float>(); 
    
    public override void Initiate(BranchUpgradeData branchUpgradeData)
    {
        _voidTowerResistanceShredAbilityLevelData = branchUpgradeData.BranchLevelsUpgradeData as VoidTowerResistanceShredAbilityLevelData;
        
        Upgrade(0);
    }

    public override void Upgrade(int levelIndex)
    {
        if (levelIndex > 0)
        {
            foreach (var enemy in _enemies)
            {
                RemoveResistanceShreds(enemy);
            }
            _resistanceShreds.Clear();
        }
        foreach (var resistanceType in _voidTowerResistanceShredAbilityLevelData.ResistanceShredsStats[levelIndex].Shreds)
        {
            _resistanceShreds.Add(resistanceType.Key, resistanceType.Value);
        }
        foreach (var enemy in _enemies)
        {
            ApplyResistanceShreds(enemy);
        }
    }
    
    private void Start()
    {
        InitialResistanceShredsCast();
    }

    private void InitialResistanceShredsCast()
    {
        _tower = GetComponent<Tower>();
        var colliders = Physics2D.OverlapCircleAll(transform.position, _tower.Range, LayerMask.GetMask("Enemy"));
        foreach (var collider in colliders)
        {
            AddEnemy(collider);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            AddEnemy(other);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            RemoveEnemy(other);
        }
    }
    
    private void AddEnemy(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponent<Enemy>();
        ApplyResistanceShreds(enemy);
        _enemies.Add(enemy);
    }
    
    private void RemoveEnemy(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        RemoveResistanceShreds(enemy);
        _enemies.Remove(enemy);
    }

    private void ApplyResistanceShreds(Enemy enemy)
    {
        foreach (var resistanceShred in _resistanceShreds)
        {
            enemy.DecreaseDamageResistance(resistanceShred.Value, resistanceShred.Key);
        }
    }

    private void RemoveResistanceShreds(Enemy enemy)
    {
        foreach (var resistanceShred in _resistanceShreds)
        {
            enemy.IncreaseDamageResistance(resistanceShred.Value, resistanceShred.Key);
        }
    }
}
