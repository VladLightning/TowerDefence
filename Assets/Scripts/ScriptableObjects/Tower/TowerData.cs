using UnityEngine;

public class TowerData : EntityData
{
    [SerializeField] protected float _range;
    public float Range => _range;

    [SerializeField] protected int _price;
    public int Price => _price;
}
