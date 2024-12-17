using UnityEngine;

public class DetectOpponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Mob>().State == MobStatesEnum.MobStates.Fighting)
        {
            return;
        }
        GetComponentInParent<Mob>().StartEnterCombat(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponentInParent<Mob>().ExitCombat(other.gameObject);
    }
}