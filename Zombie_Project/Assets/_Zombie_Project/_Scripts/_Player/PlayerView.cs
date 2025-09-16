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
        //playerFireAction.action.performed += ctx =? 
    }
}
