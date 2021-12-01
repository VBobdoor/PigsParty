using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Agent))]
public class TakingDamage : MonoBehaviour
{
    private Agent agent;
    private float DamageImmuneCooldown = 2f;
    private bool immuneToDamage = false;

    private void Awake()
    {
        agent = GetComponent<Agent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(!immuneToDamage)
            TakeDamage();
    }

    private void TakeDamage()
    {
        agent.TakeDamage();
        Destroy(gameObject, 2.5f);
        StartCoroutine(TakeDamageImmune());
    }

    private IEnumerator TakeDamageImmune()
    {
        immuneToDamage = true;
        yield return new WaitForSeconds(DamageImmuneCooldown);
        immuneToDamage = false;
    }
}
