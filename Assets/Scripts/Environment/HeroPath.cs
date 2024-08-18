using UnityEngine;

public class HeroPath : MonoBehaviour
{
    private Hero _hero;
    public Hero Hero { set { _hero = value; } }

    private void OnMouseDown()
    {
        _hero.StartMovement();
    }
}
