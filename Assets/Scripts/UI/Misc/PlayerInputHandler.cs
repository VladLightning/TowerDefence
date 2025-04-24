
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private WindowPresenter _windowPresenter;
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _glossary;

    private Ability[] _heroAbilities = new Ability[3];

    private int _selectedAbilityIndex;

    private void OnEnable()
    {
        HeroSpawner.OnAbilitiesSpawned += InitPlayerAbilities;
    }

    private void OnDisable()
    {
        HeroSpawner.OnAbilitiesSpawned -= InitPlayerAbilities;
    }

    private void InitPlayerAbilities(Ability[] abilities)
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

    public void OnAbilityDeselect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DeselectAbility();
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

    public void OnGlossary(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_glossary.activeSelf)
            {
                _windowPresenter.RemoveWindow(_glossary);
            }
            else
            {
                _windowPresenter.AddWindow(_glossary);
            }
        }
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_windowPresenter.IsWindowOpen)
            {
                _windowPresenter.RemoveWindow();
            }
            else
            {
                _windowPresenter.AddWindow(_menu);
            }
        }
    }

    private void SelectAbility(int index)
    {
        DeselectAbility();
        _heroAbilities[index].TrySelectAbility();
        _selectedAbilityIndex = index;
    }

    private void DeselectAbility()
    {
        _heroAbilities[_selectedAbilityIndex].DeselectAbility();
    }
}
