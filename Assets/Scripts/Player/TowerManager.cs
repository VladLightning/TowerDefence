using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private Transform _buildPosition;

    public void SetBuildPosition(Transform buildPosition)
    {
        gameObject.SetActive(true);
        _buildPosition = buildPosition;
    }

    public void BuildTower(GameObject towerToBuild)
    {
        Instantiate(towerToBuild, _buildPosition.position, towerToBuild.transform.rotation);
        gameObject.SetActive(false);
    }
}
