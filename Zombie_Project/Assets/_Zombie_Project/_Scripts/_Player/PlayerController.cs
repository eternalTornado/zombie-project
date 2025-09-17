using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel playerModel;
    public PlayerView playerView;
    private Vector2 moveInput;
    private Vector2 mousePosition;
    private bool isPlayerShooting;
    private CharacterController characterController;
    public Camera mainCamera;
    public Transform player;
    //public WeaponController weaponController;

    private void OnEnable()
    {
        EventManager.LatestMovementInput += ReceiveLatestMoveInput;
        EventManager.LatestMousePosition += ReceiveLatestMousePositionInput;
        EventManager.WeaponFireStarted += EnablePlayerShootingStatus;
        EventManager.WeaponFireStopped += DisablePlayerShootingStatus;
        EventManager.PlayerKilled += OnPlayerKilled;
    }

    private void OnDisable()
    {
        EventManager.LatestMovementInput -= ReceiveLatestMoveInput;
        EventManager.LatestMousePosition -= ReceiveLatestMousePositionInput;
        EventManager.WeaponFireStarted -= EnablePlayerShootingStatus;
        EventManager.WeaponFireStopped -= DisablePlayerShootingStatus;
        EventManager.PlayerKilled -= OnPlayerKilled;
    }

    private void Update()
    {
        ControlPlayerMovement();
        ControlPlayerRotation();
        ControlPlayerShoot();
    }

    private void ControlPlayerMovement()
    {
        if (moveInput != Vector2.zero)
        {
            Vector3 moveVector = new(moveInput.x, 0, moveInput.y);
            characterController.Move(moveVector * playerModel.moveSpeed * Time.deltaTime);
        }
    }

    private void ControlPlayerRotation()
    {
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 lookDirection = hitInfo.point - player.position;
            lookDirection.y = 0; // Keep only horizontal rotation
            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                player.rotation = Quaternion.Slerp(player.rotation, targetRotation, playerModel.rotateSpeed * Time.deltaTime);
            }
        }
    }

    private void ControlPlayerShoot()
    {
        playerView.SetPlayerFireStatus(isPlayerShooting);
    }

    #region Event Callback methods

    private void ReceiveLatestMoveInput(Vector2 input)
    {
        moveInput = input;
    }

    private void ReceiveLatestMousePositionInput(Vector2 input)
    {
        mousePosition = input;
    }

    private void EnablePlayerShootingStatus()
    {
        isPlayerShooting = true;
        //weaponController.StartFiring();
    }

    private void DisablePlayerShootingStatus()
    {
        isPlayerShooting = false;
        //weaponController.StopFiring();
    }

    #endregion

    private void OnPlayerKilled()
    {
        EventManager.GameEnded?.Invoke();
        gameObject.SetActive(false);
    }
}
