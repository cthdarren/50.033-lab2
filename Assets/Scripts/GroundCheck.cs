using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerData playerData;
    public LayerMask groundLayer;

    public void FixedUpdate()
    {
        //playerData.isGrounded = Physics2D.Raycast(
        //    this.transform.position,
        //    Vector2.down,
        //    0.1f,
        //    groundLayer
        //);
        //if (playerData.isJumping && playerData.isGrounded)
        //    playerData.isJumping = false;
    }
}
