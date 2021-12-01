using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject[] healthBar;
    [SerializeField] GameObject loseScreen;
    private int health = 3;

    public void LoseHealth(int damage)
    {
        health -= damage;
        if (health < 1)
            Death();
        else
           healthBar[health].SetActive(false);
    }

    private void Death()
    {
        FullOffHealthBar();
        gameObject.SetActive(false);
        loseScreen.SetActive(true);
    }

    private void FullOffHealthBar()
    {
        for (int i = 0; i < 3; i++)
        {
            healthBar[i].SetActive(false);
        }
    }
}
