using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTakingDamage playerTakingDamage = collision.GetComponent<PlayerTakingDamage>();
        playerTakingDamage.TakeDamage(damage);
    }
}
