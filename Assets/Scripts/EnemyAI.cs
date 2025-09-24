using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemyData enemyData;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform playerTransform;
    private enum AIState { Idle, Chasing, Attacking }
    private AIState currentState;
    private float currentHealth;
    private float attackTimer;
    private bool isDead = false;
    private int attackStateHash;
    private int idleStateHash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        currentHealth = enemyData.health;

        attackStateHash = Animator.StringToHash("boss-attack");
        idleStateHash = Animator.StringToHash("boss-idle");

        // Start in the Idle state
        currentState = AIState.Idle;
    }

    void Update()
    {
        if (isDead) return;

        switch (currentState)
        {
            case AIState.Idle:
                IdleState();
                break;
            case AIState.Chasing:
                ChaseState();
                break;
            case AIState.Attacking:
                AttackState();
                break;
        }

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private void IdleState()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        animator.SetBool("isWalking", false);

        if (Vector2.Distance(transform.position, playerTransform.position) < enemyData.detectionRange)
        {
            currentState = AIState.Chasing;
        }
    }

    private void ChaseState()
    {
        animator.SetBool("isWalking", true);

        if (Vector2.Distance(transform.position, playerTransform.position) < enemyData.attackRange)
        {
            currentState = AIState.Attacking;
            return;
        }

        if (Vector2.Distance(transform.position, playerTransform.position) > enemyData.detectionRange)
        {
            currentState = AIState.Idle;
            return;
        }

        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * enemyData.moveSpeed, rb.linearVelocity.y);

        if (direction.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    private void AttackState()
    {
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("isWalking", false);

        if (attackTimer <= 0)
        {
            animator.SetTrigger("Attack");
            attackTimer = enemyData.attackCooldown;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == idleStateHash)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) > enemyData.attackRange)
            {
                currentState = AIState.Chasing;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (currentStateInfo.shortNameHash != attackStateHash)
        {
            animator.SetTrigger("Hurt");
        }

    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("Death");

        rb.linearVelocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}