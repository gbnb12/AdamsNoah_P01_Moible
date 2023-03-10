using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TouchManager : MonoBehaviour
{

    public bool IsTapPressed { get; private set; } = false;
    //TODO add other input events here

    [SerializeField]
    private GameObject player;

    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    [SerializeField] protected AudioClip _moveSound;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
        position.z = player.transform.position.z;
        player.transform.position = position;                                                                                
    }

    private void Update()
    {
        touchPositionAction.ReadValue<Vector2>();
        if (touchPressAction.WasPerformedThisFrame())
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
            position.z = player.transform.position.z;
            player.transform.position = position;
            IsTapPressed = true;
            MoveFeedback();
        }
    }

    private void MoveFeedback()
    {
        if (_moveSound != null)
        {
            AudioHelper.PlayClip2D(_moveSound, 1f);

        }
    }
}
