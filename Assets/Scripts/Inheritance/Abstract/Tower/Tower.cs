using System;
using System.Collections;
using UnityEngine;

public abstract class Tower : Entity
{
    private const float DELAY_FOR_ROTATION = 0.2f;
    private const float SELL_PRICE_COEFFICIENT = 0.5f;
    
    [SerializeField] private Transform _projectileLaunchPoint; 
    private TowerLevelsData _towerLevelsData;
    
    private GameObject _projectile;
    
    private float _lastShotTime;
    
    private Transform _target;
    private CircleCollider2D _collider2D;
    
    
    private PlayerMoney _playerMoney;
    private TowerLevels[] _towerLevels;
    public TowerLevels[] TowerLevels => _towerLevels;
    
    private int _towerLevelIndex;
    public int TowerLevelIndex => _towerLevelIndex;
    
    private float _range;
    private int _price;
    private int _rotationSpeed;
    
    [SerializeField] private TowerBranchData[] _towerBranchData;
    public TowerBranchData[] TowerBranchData => _towerBranchData;

    private TowerBranchData _currentTowerBranchData;
    public TowerBranchData CurrentTowerBranchData => _currentTowerBranchData;
    
    private int[] _currentBranchUpgradeLevels;
    
    
    private DefaultProjectileData _defaultProjectileData;
    
    private StatusProjectileData _statusProjectileData;
    
    private IEnumerator _shoot;
    private bool _shootingIsActive;

    protected override void Awake()
    {
        _collider2D = GetComponent<CircleCollider2D>();
        _towerLevelsData = _entityData as TowerLevelsData;
        _towerLevels = _towerLevelsData.TowerLevels;
        
        _projectile = _towerLevelsData.ProjectileData.ProjectilePrefab;
        _defaultProjectileData = _towerLevelsData.ProjectileData as DefaultProjectileData;
        
        base.Awake();
    }
    
    public void Initiate(PlayerMoney playerMoney)
    {
        _playerMoney = playerMoney;      
    }

    private void SetStats(TowerLevels towerLevelsData)
    {
        _attackSpeed = towerLevelsData.AttackSpeed;
        _range = towerLevelsData.Range;
        _price = towerLevelsData.Price;
        _rotationSpeed = towerLevelsData.RotationSpeed;

        _collider2D.radius = _range;      
    }

    protected override void SetStats()
    {
        _attackSpeed = _towerLevels[_towerLevelIndex].AttackSpeed;
        _range = _towerLevels[_towerLevelIndex].Range;
        _price += _towerLevels[_towerLevelIndex].Price;
        _rotationSpeed = _towerLevels[_towerLevelIndex].RotationSpeed;

        _collider2D.radius = _range;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_shootingIsActive)
        {
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform == _target)
        {
            FindTarget();
        }
    }

    private void Start()
    {
        //Сделано для того, чтобы башне не пришлось ждать задержку выстрела, если враг попадает зону стрельбы в начале жизненного цикла
        _lastShotTime = -_attackSpeed;
    }

    private void Update()
    {
        if(_target != null)
        {
            LookAtTarget();
        }
    }

    private void FindTarget()
    {
        var enemyColliders = Physics2D.OverlapCircleAll(transform.position, _range, LayerMask.GetMask("Enemy"));

        if(enemyColliders.Length == 0)
        {
            _target = null;
            DeactivateShoot();
            return;
        }

        float shortestDistance = enemyColliders[0].GetComponent<Enemy>().GetDistanceToCastle();
        float newDistance;
        int shortestDistanceIndex = 0;

        for (int i = 1; i < enemyColliders.Length; i++)
        {          
            newDistance = enemyColliders[i].GetComponent<Enemy>().GetDistanceToCastle();
            if (shortestDistance > newDistance)
            {
                shortestDistance = newDistance;
                shortestDistanceIndex = i;
            }
        }
        _target = enemyColliders[shortestDistanceIndex].transform;
    }

    private void LookAtTarget()
    {
        Vector2 targetDirection = _target.position - transform.position;
       
        float angle = Vector2.SignedAngle(transform.up, targetDirection);
       
        transform.Rotate(Vector3.forward, angle * _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Shoot(float delay)
    {
        _shootingIsActive = true;
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTarget();
            yield return new WaitForSeconds(DELAY_FOR_ROTATION);

            var projectile = Instantiate(_projectile, _projectileLaunchPoint.position, _projectileLaunchPoint.rotation).GetComponent<Projectile>();
            if (_statusProjectileData != null)
            {
                var statusProjectile = projectile as StatusProjectile;
                statusProjectile.Initialize(_statusProjectileData.StatusProjectileStats[_currentBranchUpgradeLevels[0] - 1], _statusProjectileData.DamageType);
                // -1 из-за того, что при покупке абилки, уровень сразу становится 1, а на первый уровень нужен индекс 0
            }
            else
            {
                projectile.Initialize(_defaultProjectileData.ProjectileLevels[_towerLevelIndex]);
            }

            _lastShotTime = Time.time;          
            delay = _attackSpeed;
        }
    }
    
    private void DeactivateShoot()
    {
        _shootingIsActive = false;
        StopCoroutine(_shoot);
    }

    private void Attack()
    {
        float delay = (Time.time - _lastShotTime > _attackSpeed) ? 0 : _attackSpeed - (Time.time - _lastShotTime);

        _shoot = Shoot(delay);
        StartCoroutine(_shoot);
    }
    
    public void SetStatusProjectile(StatusProjectileData statusProjectileData)
    {
        _statusProjectileData = statusProjectileData;
        _projectile = _statusProjectileData.ProjectilePrefab;
    }

    public bool IsMaxLevel()
    {
        return _towerLevelIndex == TowerLevelsData.MAX_TOWER_LEVEL;
    }

    public bool IsUpgradeAvailable()
    {
        return !IsMaxLevel() && TowerLevels[TowerLevelIndex].Price <= _playerMoney.MoneyAmount;
    }

    public void Upgrade()
    {
        _towerLevelIndex++;
        _playerMoney.Purchase(_towerLevels[_towerLevelIndex].Price);
        SetStats();
    }

    public void Sell()
    {
        _playerMoney.AddMoney((int)(SELL_PRICE_COEFFICIENT * _price));
        Destroy(gameObject);
    }

    public void SetBranch(int index)
    {      
        _currentTowerBranchData = _towerBranchData[index];
        _playerMoney.Purchase(_currentTowerBranchData.TowerLevels[0].Price);
        GetComponent<SpriteRenderer>().sprite = _currentTowerBranchData.TowerSprite;

        _currentBranchUpgradeLevels = new int[_currentTowerBranchData.BranchUpgradesData.Length];

        SetStats(_currentTowerBranchData.TowerLevels[0]);
    }

    public void UpgradeBranchAbility(int index)
    {
        if (_currentBranchUpgradeLevels[index] == 0)
        {
            var type = Type.GetType(_currentTowerBranchData.BranchUpgradesData[index].UpgradeClassName);
            
            var ability = gameObject.AddComponent(type) as BranchAbility;
            ability.Initiate(_currentTowerBranchData.BranchUpgradesData[index]);
        }
        
        _currentBranchUpgradeLevels[index]++;
    }

    public int GetInitialPrice()
    {
        var towerLevelsData = _entityData as TowerLevelsData;
        return towerLevelsData.TowerLevels[0].Price;
    }

    public int GetCurrentUpgradeLevel(int index)
    {
        return _currentBranchUpgradeLevels[index];
    }
}