using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Collider2D attackHitbox;
    public PlayerData playerData;
    public PlayerInput input;
    public GameEvent attackEvent;

    public void HandleCombat()
    {
        if (isDead())
        {
            // Play death animation + ui screen
        }
        if (input.attackInput.WasPressedThisFrame())
        {
            Attack();
        }
    }
    public bool isDead()
    {
        return playerData.hp < 0;
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
        if (playerData.isDashing) return;
        animator.SetTrigger("Attack");
        attackEvent.Raise();
        attackHitbox.enabled = true;
        StartCoroutine(WaitForAttackHitboxWindow());
    }

    public IEnumerator WaitForAttackHitboxWindow()
    {
        yield return new WaitForSeconds(0.1f);
        attackHitbox.enabled = false;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // EnemyPrefab.TakeDamage();
        }
    }
}
