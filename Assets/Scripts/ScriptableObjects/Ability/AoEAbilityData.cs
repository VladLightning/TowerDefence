
using UnityEngine;

public abstract class AoEAbilityData : AbilityData
{
    [SerializeField] private float _radius;
    public float Radius => _radius;
}
