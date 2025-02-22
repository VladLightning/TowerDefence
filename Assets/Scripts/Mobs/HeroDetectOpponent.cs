using UnityEngine;

public class HeroDetectOpponent : MonoBehaviour
{
    private readonly float _detectionRadius = 3;
    
    [SerializeField] private LayerMask _detectionLayerMask;
    
    private Mob _hero;
    private Mob _opponent;

    private void Start()
    {
        _hero = GetComponentInParent<Mob>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SearchPotentialOpponent();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_opponent != other.GetComponent<Mob>())
        {
            return;
        }

        StopFighting();
    }

    public void SearchPotentialOpponent()
    {
        var mob = Physics2D.OverlapCircle(transform.position, _detectionRadius, _detectionLayerMask);
        if (mob == null)
        {
            return;
        }
        
        var potentialOpponent = mob.GetComponent<Mob>();
        if (potentialOpponent.CurrentState == MobStatesEnum.MobStates.Fighting || _hero.CurrentState != MobStatesEnum.MobStates.Idle)
        {
            return;
        }
        _opponent = potentialOpponent;
  
        _hero.EnterCombat(_opponent);
        _opponent.EnterCombat(_hero);
    }

    public void StopFighting()
    {
        if (_opponent == null)
        {
            return;
        }
        
        if (_hero.CurrentState == MobStatesEnum.MobStates.Fighting)
        {
            _hero.ChangeState(MobStatesEnum.MobStates.Idle);
        }
        
        _hero.ExitCombat();
        
        _opponent.ChangeState(MobStatesEnum.MobStates.Moving);
        _opponent.ExitCombat();

        _opponent = null;
    }
}