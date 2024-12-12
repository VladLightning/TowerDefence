using UnityEngine;

public class TornadoAbility : AoEAbility
{
    [SerializeField] private GameObject _tornadoPrefab;

    private void InitTornado(GameObject tornadoInstance)
    {
        var tornado = tornadoInstance.GetComponent<Tornado>();
        var abilityData = _abilityData as TornadoAbilityData;
        
        tornado.TornadoActivate(abilityData.Mask, abilityData.TornadoForceMagnitude, abilityData.TornadoDuration, abilityData.Radius);
    }
    
    protected override void AbilityCast()
    {
        base.AbilityCast();
        var tornadoInstance = Instantiate(_tornadoPrefab, GetMousePosition(), _tornadoPrefab.transform.rotation);

        InitTornado(tornadoInstance);
    }
}
