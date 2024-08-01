using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] private GameObject[] _towers;

    public GameObject GetTower(TowersEnum.TowerTypes type)
    {
        return _towers[(int)type];
    }
}

