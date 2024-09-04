using UnityEngine;
public class TowerManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;
    private Towers _towers;

    private Transform _buildSiteTransform;

    private void Start()
    {
        _towers = GetComponent<Towers>();
    }

    public void SetBuildPosition(Transform buildPosition)
    {
        gameObject.SetActive(true);
        _buildSiteTransform = buildPosition;
    }

    public void BuildTower(TowersEnum.TowerTypes towerType)
    {
        int price = _towers.GetStats(towerType).Price;
        if (price > _playerMoney.MoneyAmount)
        {
            return;
        }
        
        Vector3 spawnPosition = new Vector3(_buildSiteTransform.position.x, _buildSiteTransform.position.y, -1); // Z = -1 для того, чтобы не было конфликтов между слоями

        var tower = Instantiate(_towers.GetTower(towerType), spawnPosition, transform.rotation, _buildSiteTransform).GetComponent<Tower>();                                                                       
        tower.Initiate(_towers.GetStats(towerType), _playerMoney);

        _playerMoney.Purchase(price);

        gameObject.SetActive(false);
    }
}
