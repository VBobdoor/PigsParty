using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float bombCooldown = 3f;
    [SerializeField] private GameObject bombSpritesObject;
    private ParticleSystem particalSystem;

    private void Awake()
    {
        particalSystem = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        bombCooldown -= Time.deltaTime;

        if(bombCooldown <= 0)
        {
            particalSystem.Play();
            bombSpritesObject.SetActive(false);
            Destroy(gameObject,1);
        }


    }
}
