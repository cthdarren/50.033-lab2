using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public EnemyData enemyData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCombat player = other.GetComponent<PlayerCombat>();
            if (player != null)
            {
                player.TakeDamage(enemyData.attackDamage);

                gameObject.SetActive(false);
            }
        }
    }
}