using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private Menu _menu;

    private Ability[] _heroAbilities = new Ability[3];

    private int _selectedAbilityIndex;

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
            if (_heroAbilities[_selectedAbilityIndex].IsSelected)
            {
                _heroAbilities[_selectedAbilityIndex].UseAbility();
                return;
            }
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
            SelectAbility(0);
        }
    }

    public void OnSecondAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SelectAbility(1);
        }
    }

    public void OnThirdAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SelectAbility(2);
        }
    }

    private void SelectAbility(int index)
    {
        _heroAbilities[_selectedAbilityIndex].AbilitySelected(false);
        _heroAbilities[index].AbilitySelected(true);
        _selectedAbilityIndex = index;
    }
}
