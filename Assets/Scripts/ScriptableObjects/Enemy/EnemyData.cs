using UnityEngine;

public abstract class EnemyData : MobData
{
    [SerializeField] private int _damageToPlayer;
    public int DamageToPlayer => _damageToPlayer;
    [SerializeField] private int _moneyOnDeath;
    public int MoneyOnDeath => _moneyOnDeath;
}
