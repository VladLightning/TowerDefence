using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] private GameObject[] _towers;

    private TowersEnum.TowerTypes _towerType;
    public TowersEnum.TowerTypes TowerType { set { _towerType = value; } private get { return _towerType; } }

    public GameObject Tower 
    {   get
        {
            switch (_towerType)
            {
                case TowersEnum.TowerTypes.Common: return _towers[0];

                case TowersEnum.TowerTypes.Flame: return _towers[1];

                case TowersEnum.TowerTypes.Freeze: return _towers[2];

                case TowersEnum.TowerTypes.Void: return _towers[3];

                default: return null;
            };
        }
    }
}

