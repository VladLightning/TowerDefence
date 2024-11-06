using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private Menu _menu;

    private Ability[] _heroAbilities = new Ability[3];

    public void InitPlayerAbilities(Ability[] abilities)
    {
        for (int i = 0; i < _heroAbilities.Length; i++)
        {
            _heroAbilities[i] = abilities[i];
        }
    }

    public void OnMouseInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _mouseInput.MouseInputHandler();
        }
    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _menu.Open();
        }
    }

    public void OnFirstAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _heroAbilities[0].AbilityCast();
        }
    }

    public void OnSecondAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _heroAbilities[1].AbilityCast();
        }
    }

    public void OnThirdAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _heroAbilities[2].AbilityCast();
        }
    }
}
