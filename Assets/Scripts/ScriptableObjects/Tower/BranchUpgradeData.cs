using UnityEngine;
[CreateAssetMenu(fileName = "BranchUpgrades", menuName = "UpgradesData")]
public class BranchUpgradeData : ScriptableObject
{
    [SerializeField] private string _upgradeClassName;
    public string UpgradeClassName => _upgradeClassName;
    
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField] private int[] _upgradePrices;
    public int[] UpgradePrices => _upgradePrices;
}
