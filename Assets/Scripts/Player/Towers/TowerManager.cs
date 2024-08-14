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
        _playerMoney.Purchase(price);

        var tower = Instantiate(_towers.GetTower(towerType), _buildSiteTransform.position, transform.rotation).GetComponent<Tower>();
        tower.SetStats(_towers.GetStats(towerType));
        gameObject.SetActive(false);
    }
}
