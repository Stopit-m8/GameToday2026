using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    public Vector2 Direction { get; private set; }
    private MovementPlayer movementPlayer;
    private InteractPlayer interactPlayer;
    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {
        movementPlayer = GetComponent<MovementPlayer>();
        interactPlayer = GetComponent<InteractPlayer>();
        foreach (var map in playerInput.actions.actionMaps)
        {
            map.Disable();
        }
        playerInput.actions.FindActionMap("Player").Enable();
        foreach (var map in playerInput.actions.actionMaps)
        {
            Debug.Log($"{map.name}: {map.enabled}");
        }
    }
    public void Movement(InputAction.CallbackContext ctx)
    {
        Direction = ctx.ReadValue<Vector2>();
        movementPlayer.Move(Direction);
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            interactPlayer.Interact();
        }
    }

    public void ContinueDialogue(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            DialogueManager.instance.DisplayNextSentence();
        }
    }
}
