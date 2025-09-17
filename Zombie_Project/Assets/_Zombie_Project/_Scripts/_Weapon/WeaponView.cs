using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponView : MonoBehaviour
{
    public InputActionReference selectPistolInput;
    public InputActionReference selectRifleInput;

    private void OnEnable()
    {
        selectPistolInput.action.performed += ctx => OnSelectPistolButtonPressed(ctx);
        selectRifleInput.action.performed += ctx => OnSelectRifleButtonPressed(ctx);
    }

    private void OnDisable()
    {
        selectPistolInput.action.performed -= ctx => OnSelectPistolButtonPressed(ctx);
        selectRifleInput.action.performed -= ctx => OnSelectRifleButtonPressed(ctx);
    }

    private void OnSelectPistolButtonPressed(InputAction.CallbackContext context)
    {

    }

    private void OnSelectRifleButtonPressed(InputAction.CallbackContext context)
    {

    }
}
