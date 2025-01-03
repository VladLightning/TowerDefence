using UnityEngine;
public abstract class BranchUpgradeData : ScriptableObject
{
    public abstract string UpgradeClassName { get; }
    
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField] private int[] _upgradePrices;
    public int[] UpgradePrices => _upgradePrices;
}
