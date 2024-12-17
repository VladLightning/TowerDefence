using UnityEngine;

public class DetectOpponent : MonoBehaviour
{
    private Mob _mob;

    private void Start()
    {
        _mob = GetComponentInParent<Mob>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Mob>().CurrentState == MobStatesEnum.MobStates.Fighting)
        {
            return;
        }
        _mob.StartEnterCombat(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _mob.ExitCombat(other.gameObject);
    }
}