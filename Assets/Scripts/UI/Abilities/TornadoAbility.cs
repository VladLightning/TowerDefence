using UnityEngine;

public class TornadoAbility : Ability
{
    [SerializeField] private GameObject _tornadoPrefab;

    private void InitTornado(GameObject tornadoInstance)
    {
        var tornado = tornadoInstance.GetComponent<Tornado>();
        var abilityData = _abilityData as TornadoAbilityData;
        
        tornado.SetTornadoStats(abilityData.Mask, abilityData.TornadoForceMagnitude, abilityData.TornadoDuration);
        tornado.TornadoActivate();
    }
    
    protected override void AbilityCast()
    {
        base.AbilityCast();
        var tornadoInstance = Instantiate(_tornadoPrefab, GetMousePosition(), _tornadoPrefab.transform.rotation);

        InitTornado(tornadoInstance);
    }
}
