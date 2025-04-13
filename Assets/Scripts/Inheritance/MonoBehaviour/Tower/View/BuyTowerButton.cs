using UnityEngine;
using System;
public class BuyTowerButton : MonoBehaviour
{  
    public static event Action<TowersEnum> OnBuyTowerButtonClicked;
    
    [SerializeField] private TowersEnum _towerType;

    public void OnClick()
    {       
        OnBuyTowerButtonClicked?.Invoke(_towerType);
    }
}
