using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    private MovementPlayer movementPlayer;
    private InteractPlayer interactPlayer;

    private void Awake()
    {
        movementPlayer = GetComponent<MovementPlayer>();
        interactPlayer = GetComponent<InteractPlayer>();
    }
    public void Movement(InputAction.CallbackContext ctx)
    {
        Direction = ctx.ReadValue<Vector2>();
        movementPlayer.Move(Direction);
    }

    public void Interact(InputAction.CallbackContext ctx)
    {

    }
}
