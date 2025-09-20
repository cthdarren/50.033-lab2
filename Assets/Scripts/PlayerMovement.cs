using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput input;
    public float maxFallSpeed = 50f;
    public float moveDirectionVector = 1;
    public float moveSpeed = 5;
    public float jumpHeight;
    public float isJumping;
    public float isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.wasdInputVector.WasPressedThisFrame())
        {
            moveDirectionVector = input.wasdInputVector.ReadValue<Vector2>().x;
            HandleFaceDirection();
        }
        if (input.jumpInput.ReadValue<float>() >= 1)
            isJumping = 1;
    }

    void HandleFaceDirection()
    {
        Debug.Log(moveDirectionVector);
        Vector3 vector3scale = this.transform.localScale;
        this.transform.localScale = new Vector3(moveDirectionVector*Mathf.Abs(vector3scale.x), vector3scale.y, vector3scale.z);

    }
}
