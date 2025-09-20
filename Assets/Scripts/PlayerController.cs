using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;
    public PlayerInput playerInput;
    public void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void Update()
    {
        playerMovement.HandleMovement();
        animator.SetFloat("Speed", Mathf.Abs(playerMovement.rb.linearVelocityX));
    }
}
