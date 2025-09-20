using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData: ScriptableObject
{
    public float targetSpeed;
    public float maxSpeed;
    public float jumpHangTimeThreshold;
    public float jumpHangGravityScale;
    public float fallingGravityScale;
    public float defaultGravityScale;
    public float dashDuration;
    public float dashDelay;
    public float dashCooldown;
    public float dashCooldownTimer;
    public float dashForce;
    public float jumpForce;
    public float maxFallSpeed;
    public float hp;
    public float damage;
    public bool isJumping;
    public bool isDashing;
    public bool isGrounded;
    public bool isInvincible;
    public bool isMovementDisabled;
}
