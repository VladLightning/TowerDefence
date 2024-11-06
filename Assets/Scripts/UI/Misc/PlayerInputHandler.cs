using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private Menu _menu;

    [SerializeField] private Ability _heroDefaultAbility;
    private Ability _heroSecondAbility;
    
    private Ability _heroThirdAbillity;

    public void InitPlayerAbilities(Ability[] abilities)
    {
        _heroSecondAbility = abilities[0];
        _heroThirdAbillity = abilities[1];
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
            _heroDefaultAbility.AbilityCast();
        }
    }

    public void OnSecondAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _heroSecondAbility.AbilityCast();
        }
    }

    public void OnThirdAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _heroThirdAbillity.AbilityCast();
        }
    }
}
