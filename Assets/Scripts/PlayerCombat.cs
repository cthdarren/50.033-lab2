using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Collider2D attackHitbox;
    public PlayerData playerData;
    public PlayerInput input;

    public void HandleCombat()
    {
        if (input.attackInput.WasPressedThisFrame())
        {
            Attack();
        }
    }

    public void TakeDamage(float damage)
    {
        if (playerData.isInvincible) return;
        playerData.hp -= damage;
    }

    public void Heal(float health)
    {
        playerData.hp += health;
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // EnemyPrefab.TakeDamage();
        }
    }
}
