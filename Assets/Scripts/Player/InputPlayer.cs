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
    }
    public void Movement(InputAction.CallbackContext ctx)
    {
        Direction = ctx.ReadValue<Vector2>();
        movementPlayer.Move(Direction);
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            interactPlayer.Interact();
        }
    }

    public void ContinueDialogue(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (DialogueManager.instance.isTyping)
            {
                Debug.Log("I'm speed");
                DialogueManager.instance.SpeedType();
                return;
            }
            Debug.Log("play dialogue");
            DialogueManager.instance.DisplayNextSentence();
        }
    }
}
