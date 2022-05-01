using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    private InputAction moveAction;
    private Vector2 delta = Vector2.zero;

    private void Awake()
    {
        moveAction = input.FindActionMap("Player").FindAction("Move");
        moveAction.performed += MoveAction_Changed;
        moveAction.canceled += MoveAction_Changed;
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void FixedUpdate()
    {
        transform.Translate(delta);
    }

    private void MoveAction_Changed(InputAction.CallbackContext callback)
    {
        delta = callback.ReadValue<Vector2>() * new Vector2(0.1f, 0.1f);
    }
}
