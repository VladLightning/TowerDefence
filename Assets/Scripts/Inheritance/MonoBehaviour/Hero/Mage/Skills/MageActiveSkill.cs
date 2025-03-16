
using UnityEngine;

public class MageActiveSkill : MonoBehaviour, IActiveHeroSkill
{
    public void ActiveSkillTrigger()
    {
        Debug.Log("ActiveSkillTrigger");
    }
}
