using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerTakingDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private int bombDamage = 1;
    private float DamageImmuneCooldown = 2f;
    private bool immuneToDamage = false;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!immuneToDamage)
            TakeDamage(bombDamage);
    }

    public void TakeDamage(int damage)
    {
        playerHealth.LoseHealth(damage);
        StartCoroutine(TakeDamageImmune());
    }

    private IEnumerator TakeDamageImmune()
    {
        immuneToDamage = true;
        yield return new WaitForSeconds(DamageImmuneCooldown);
        immuneToDamage = false;
    }
}
