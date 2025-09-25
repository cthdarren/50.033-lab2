using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Collider2D attackHitbox;
    public PlayerData playerData;
    public PlayerInput input;
    public GameEvent attackEvent;
    [SerializeField] private HitStop hitStop;

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
        StartCoroutine(WaitForAttackHitboxWindow());
    }

    public IEnumerator WaitForAttackHitboxWindow()
    {
        yield return new WaitForSeconds(playerData.attackHitboxDelay);
        attackHitbox.enabled = true;
        yield return new WaitForSeconds(playerData.attackHitboxDuration);
        attackHitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!attackHitbox.enabled) return; 

        if (other.CompareTag("Enemy"))
        {
            EnemyAI enemy = other.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(playerData.damage);
                hitStop.Stop(playerData.hitStopDuration);
            }
        }
    }
}
