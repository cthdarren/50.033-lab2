using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
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
        animator.SetFloat("Speed", Mathf.Abs(playerMovement.moveSpeed));
    }
}
