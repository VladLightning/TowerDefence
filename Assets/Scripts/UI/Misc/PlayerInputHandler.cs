using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private Menu _menu;

    [SerializeField] private DefaultAbility _defaultAbility;

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
}
