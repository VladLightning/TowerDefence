using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private Menu _menu;

    [SerializeField] private DefaultAbility _defaultAbility;
    [SerializeField] private SecondAbility _secondAbility;
    [SerializeField] private ThirdAbillity _thirdAbillity;

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
            _defaultAbility.AbilityCast();
        }
    }

    public void OnSecondAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _secondAbility.AbilityCast();
        }
    }

    public void OnThirdAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _thirdAbillity.AbilityCast();
        }
    }
}
