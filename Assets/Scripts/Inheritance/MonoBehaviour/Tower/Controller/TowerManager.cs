using UnityEngine;
public class TowerManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private GameObject[] _towers;
    
    [SerializeField] private GameObject _panel;

    private Transform _buildSiteTransform;

    private void Awake()
    {
        BuyTowerButton.OnBuyTowerButtonClicked += BuildTower;
        MouseInput.OnTowerSlotSelected += SetBuildPosition;
    }

    private void OnDestroy()
    {
        BuyTowerButton.OnBuyTowerButtonClicked -= BuildTower;
        MouseInput.OnTowerSlotSelected -= SetBuildPosition;
    }

    private void SetBuildPosition(Transform buildPosition)
    {
        _panel.SetActive(true);
        _buildSiteTransform = buildPosition;
    }

    private void BuildTower(TowersEnum.TowerTypes towerType)
    {
        var selectedTower = _towers[(int)towerType];
        int price = selectedTower.GetComponent<Tower>().GetInitialPrice();
        if (price > _playerMoney.MoneyAmount)
        {
            return;
        }
        
        var spawnPosition = new Vector3(_buildSiteTransform.position.x, _buildSiteTransform.position.y, -1); // Z = -1 для того, чтобы не было конфликтов между слоями

        var tower = Instantiate(selectedTower, spawnPosition, transform.rotation, _buildSiteTransform).GetComponent<Tower>();                                                                       
        tower.Initiate(_playerMoney);

        _playerMoney.Purchase(price);

        _panel.SetActive(false);
    }
}
