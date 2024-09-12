using UnityEngine;
public class TowerManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private GameObject[] _towers;

    private Transform _buildSiteTransform;

    public void SetBuildPosition(Transform buildPosition)
    {
        gameObject.SetActive(true);
        _buildSiteTransform = buildPosition;
    }

    public void BuildTower(TowersEnum.TowerTypes towerType)
    {
        GameObject selectedTower = _towers[(int)towerType];
        int price = selectedTower.GetComponent<Tower>().TowerLevelsData.Price;
        if (price > _playerMoney.MoneyAmount)
        {
            return;
        }
        
        Vector3 spawnPosition = new Vector3(_buildSiteTransform.position.x, _buildSiteTransform.position.y, -1); // Z = -1 для того, чтобы не было конфликтов между слоями

        var tower = Instantiate(selectedTower, spawnPosition, transform.rotation, _buildSiteTransform).GetComponent<Tower>();                                                                       
        tower.Initiate(_playerMoney);

        _playerMoney.Purchase(price);

        gameObject.SetActive(false);
    }
}
