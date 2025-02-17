
using System.Collections;
using UnityEngine;

public class Revive : MonoBehaviour
{
    [SerializeField] private GameObject _gravePrefab;

    private void OnEnable()
    {
        Hero.OnDeath += StartReviveMob;
    }

    private void OnDisable()
    {
        Hero.OnDeath -= StartReviveMob;
    }

    private void StartReviveMob(float respawnTime, GameObject mob)
    {
        StartCoroutine(ReviveMob(respawnTime, mob));
    }

    private IEnumerator ReviveMob(float respawnTime, GameObject mob)
    {
        var grave = Instantiate(_gravePrefab, mob.transform.position, mob.transform.rotation);
        Destroy(grave, respawnTime);
        
        yield return new WaitForSeconds(respawnTime);
        
        mob.GetComponent<Mob>().Revive();
        mob.SetActive(true);
    }
}
