using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private InputActionReference moveAction;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (moveAction != null)
        {
            moveAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (moveAction != null)
        {
            moveAction.action.Disable();
        }
    }

    private void Update()
    {
        if (moveAction == null)
        {
            movementInput = Vector2.zero;
            return;
        }

        movementInput = moveAction.action.ReadValue<Vector2>();
        movementInput = Vector2.ClampMagnitude(movementInput, 1f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
    }
}
