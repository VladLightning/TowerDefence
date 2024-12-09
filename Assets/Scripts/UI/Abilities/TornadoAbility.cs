using UnityEngine;

public class TornadoAbility : Ability
{
    [SerializeField] private GameObject _tornadoPrefab;
    
    protected override void AbilityCast()
    {
        base.AbilityCast();
        Instantiate(_tornadoPrefab, GetMousePosition(), _tornadoPrefab.transform.rotation);
    }
}
