using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerInput input;
    public Rigidbody2D rb;
    public float moveDirectionVector = 1;

    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    public void FixedUpdate()
    {
        if (playerData.isGrounded)
            playerData.isJumping = false;
            rb.gravityScale = playerData.defaultGravityScale;
    }

    public void HandleMovement()
    {
        HandleFaceDirection();
        HandleJump();

        if (input.wasdInputVector.WasReleasedThisFrame())
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
        }
        if (input.wasdInputVector.IsPressed())
        {

            // W+A = 0.707 x 
            moveDirectionVector = Mathf.Round(input.wasdInputVector.ReadValue<Vector2>().x);
            Debug.Log(moveDirectionVector);

            if (input.wasdInputVector.ReadValue<Vector2>().y <= 0)
                rb.linearVelocity = new Vector2(playerData.targetSpeed * moveDirectionVector, rb.linearVelocityY);
        }
        if (input.jumpInput.ReadValue<float>() >= 1)
            playerData.isJumping = true;
    }

    public void HandleFaceDirection()
    {
        Vector3 vector3scale = this.transform.localScale;
        if (Mathf.Abs(moveDirectionVector) >= 1)
            this.transform.localScale = new Vector3(moveDirectionVector*Mathf.Abs(vector3scale.x), vector3scale.y, vector3scale.z);
    }

    public void HandleJump()
    {
        if (input.jumpInput.WasReleasedThisFrame() && !playerData.isGrounded)
        {
            float linearYtoSet = rb.linearVelocityY > 0 ? 0 : rb.linearVelocityY;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, linearYtoSet);
        }

        if (rb.linearVelocityY <= 0)
        {
            rb.gravityScale = playerData.fallingGravityScale;
        }

        if (input.jumpInput.WasPressedThisFrame())
        {
            Debug.Log("JUmped");
            if (playerData.isGrounded)
            {
                rb.AddForce(new Vector2(0, playerData.jumpForce), ForceMode2D.Impulse);
                playerData.isJumping = true;
                playerData.isGrounded = false;
            }
        }

        // For capping max falling speeds
        if (rb.linearVelocityY < 0)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, Mathf.Max(rb.linearVelocityY, -playerData.maxFallSpeed));

        // Extend air time slightly between threshold
        if (playerData.isJumping && Mathf.Abs(rb.linearVelocityY) < playerData.jumpHangTimeThreshold)
            rb.gravityScale = playerData.jumpHangGravityScale;
    }
}
