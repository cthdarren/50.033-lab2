using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public float health = 100f;
    public float moveSpeed = 3f;
    public float attackDamage = 10f;
    public float attackRange = 1.5f; // How close the enemy needs to be to attack.
    public float attackCooldown = 2f; // Time between attacks.
    public float detectionRange = 10f; // How far away the enemy can see the player.
}