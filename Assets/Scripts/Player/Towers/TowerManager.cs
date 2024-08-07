using UnityEngine;

public class TowerManager : MonoBehaviour
{
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
        var tower = Instantiate(_towers.GetTower(towerType), _buildSiteTransform.position, transform.rotation).GetComponent<TowerShoot>();
        tower.Initialize(_towers.GetStats(towerType));
        gameObject.SetActive(false);
    }
}
