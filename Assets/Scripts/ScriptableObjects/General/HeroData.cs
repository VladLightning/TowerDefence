using UnityEngine;
public abstract class HeroData : MobData
{
    [SerializeField] private float _respawnTime;
    public float RespawnTime => _respawnTime;
    [SerializeField] private float _regenerationDelay;
    public float RegenerationDelay => _regenerationDelay;
    [SerializeField] private float _regenerationInterval;
    public float RegenerationInterval => _regenerationInterval;
    [SerializeField] private int _regenerationAmount;   
    public int RegenerationAmount => _regenerationAmount;
}