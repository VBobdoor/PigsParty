using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    private float bombSpawnCooldown = 1.5f;
    private bool ableToSpawnBomb = true;

    public void SpawnBomb()
    {
        if (ableToSpawnBomb)
        {
            StartCoroutine(setBombSpawnCooldown());
            Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }

    private IEnumerator setBombSpawnCooldown()
    {
        ableToSpawnBomb = false;
        yield return new WaitForSeconds(bombSpawnCooldown);
        ableToSpawnBomb = true;
    }
}
