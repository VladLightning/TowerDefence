using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private Transform _buildSiteTransform;

    public void SetBuildPosition(Transform buildPosition)
    {
        gameObject.SetActive(true);
        _buildSiteTransform = buildPosition;
    }

    public void BuildTower(GameObject towerToBuild)
    {
        Instantiate(towerToBuild, _buildSiteTransform.position, towerToBuild.transform.rotation);
        gameObject.SetActive(false);
    }
}
