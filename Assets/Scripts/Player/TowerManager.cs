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
        GameObject towerToBuild = _towers.GetTower(towerType);
        Instantiate(towerToBuild, _buildSiteTransform.position, towerToBuild.transform.rotation);
        gameObject.SetActive(false);
    }
}
