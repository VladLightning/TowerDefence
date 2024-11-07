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
                _heroAbilities[_selectedAbilityIndex].AbilityCast();
                _heroAbilities[_selectedAbilityIndex].AbilitySelected();
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
            DeselectAbilities();
            _heroAbilities[0].AbilitySelected();
            _selectedAbilityIndex = 0;
        }
    }

    public void OnSecondAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DeselectAbilities();
            _heroAbilities[1].AbilitySelected();
            _selectedAbilityIndex = 1;
        }
    }

    public void OnThirdAbility(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DeselectAbilities();
            _heroAbilities[2].AbilitySelected();
            _selectedAbilityIndex = 2;
        }
    }

    private void DeselectAbilities()
    {
        for (int i = 0; i < _heroAbilities.Length; i++)
        {
            if (_heroAbilities[i].IsSelected)
            {
                _heroAbilities[i].AbilitySelected();
            }         
        }
    }
}
