using UnityEngine;
using System;
public class BuyTowerButton : MonoBehaviour
{  
    public static event Action<TowersEnum.TowerTypes> OnBuyTowerButtonClicked;
    
    [SerializeField] private TowersEnum.TowerTypes _towerType;

    public void OnClick()
    {       
        OnBuyTowerButtonClicked?.Invoke(_towerType);
    }
}
