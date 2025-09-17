using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    private Vector2 moveInput;
    public Vector2 mousePosition;
    public Animator playerAnimator;
    public InputActionReference playerMovementAction;
    public InputActionReference playerFireAction;
    public InputActionReference playerRotationAction;
    private bool isFireButtonPressed;
    bool isFireAnimationAlreadyRunning;
    public bool IsFireButtonPressed
    {
        get { return isFireButtonPressed; }
        set { isFireButtonPressed = value; }
    }

    private void OnEnable()
    {
        playerFireAction.action.performed += ctx => SetFiringButtonStatus(ctx);
        playerFireAction.action.canceled += ctx => SetFiringButtonStatus(ctx);
    }

    private void OnDisable()
    {
        playerFireAction.action.performed -= ctx => SetFiringButtonStatus(ctx);
        playerFireAction.action.canceled -= ctx => SetFiringButtonStatus(ctx);
    }

    private void Update()
    {
        //Read movement input
        moveInput = playerMovementAction.action.ReadValue<Vector2>();
        EventManager.LatestMovementInput?.Invoke(moveInput);

        //Read mouse position input
        mousePosition = playerRotationAction.action.ReadValue<Vector2>();
        EventManager.LatestMousePosition?.Invoke(mousePosition);
    }

    private void SetFiringButtonStatus(InputAction.CallbackContext ctx)
    {
        isFireButtonPressed = ctx.ReadValueAsButton();
        if (IsFireButtonPressed)
        {
            EventManager.WeaponFireStarted?.Invoke();
        }
        else
        {
            EventManager.WeaponFireStopped?.Invoke();
        }
    }

    #region  Visual appearance methods

    public void SetPlayerFireStatus(bool isFiring)
    {
        if (isFiring && !isFireAnimationAlreadyRunning)
        {
            isFireAnimationAlreadyRunning = true;
            Debug.Log("Player is Shooting");
        }
        else if (!isFiring && isFireAnimationAlreadyRunning)
        {
            isFireAnimationAlreadyRunning = false;
            Debug.Log("Player Stopped Shooting");
        }
    }

    #endregion
}
