using UnityEngine;

public class HeroDetectOpponent : MonoBehaviour
{
    private Mob _hero;
    private Mob _opponent;

    private void Start()
    {
        _hero = GetComponentInParent<Mob>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var opponent = other.GetComponent<Mob>();
        if (opponent.CurrentState == MobStatesEnum.MobStates.Fighting || _hero.CurrentState != MobStatesEnum.MobStates.Idle)
        {
            return;
        }
        _opponent = opponent;
  
        _hero.EnterCombat(other.gameObject);
        _opponent.EnterCombat(transform.parent.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_opponent != other.GetComponent<Mob>())
        {
            return;
        }

        StopFighting();
    }

    public void StopFighting()
    {
        if (_hero.CurrentState == MobStatesEnum.MobStates.Fighting)
        {
            _hero.ChangeState(MobStatesEnum.MobStates.Idle);
        }
        _opponent?.ChangeState(MobStatesEnum.MobStates.Moving);
    }
}