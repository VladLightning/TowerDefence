using UnityEngine;
[CreateAssetMenu(fileName = "BranchUpgrades", menuName = "UpgradesData")]
public class BranchUpgradeData : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField] private int _price;
    public int Price => _price;
}