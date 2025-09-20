using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public InputAction wasdInputVector;
    public InputAction attackInput;
    public InputAction jumpInput;
    public void Start()
    {
        wasdInputVector = InputSystem.actions.FindAction("Move");
        attackInput = InputSystem.actions.FindAction("Attack");
        jumpInput = InputSystem.actions.FindAction("Jump");
    }

}
