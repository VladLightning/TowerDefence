using System;
using System.Collections;
using UnityEngine;

public class Invincibility : MonoBehaviour, IActiveHeroSkill
{
    private float _skillDuration;
    private float _skillCooldown;
    
    private bool _isInvincible;

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void ActiveSkillTrigger()
    {
        if (!_isInvincible)
        {
            StartCoroutine(ActivateInvincibility());
        }
    }

    private IEnumerator ActivateInvincibility()
    {
        _isInvincible = true;
        
        Debug.Log("Invincibility start");
        yield return new WaitForSeconds(_skillDuration);
        Debug.Log("Invincibility end");
        yield return new WaitForSeconds(_skillCooldown);
        
        _isInvincible = false;
    }
}
