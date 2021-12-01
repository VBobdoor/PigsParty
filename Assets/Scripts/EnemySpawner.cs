using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Text waveText;
    [SerializeField] private Transform target;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject dogEnemy;

    private int currentWave = 1;
    private int currentEnemys;
    private int enemysInWave = 1;
    private void Awake()
    {
        SpawnFirstWave();
        WaveTextUpdate();
    }
    public void enemyDead()
    {
        currentEnemys -= 1;

        if (currentEnemys < 1)
        {
            currentWave += 1;
            spawnNewWave();
            WaveTextUpdate();
        }
           
    }

    private void spawnNewWave()
    {
        enemysInWave += 2;
        currentEnemys = enemysInWave;

        for(int i = 0; i < currentEnemys; i++)
        {
            GameObject dog = Instantiate(dogEnemy, spawnPoints[i % spawnPoints.Length].position, Quaternion.identity);
            Agent dogAgent= dog.GetComponent<Agent>();
            dogAgent.Target = target;
            dogAgent.EnemySpawner = this;

        }
    }

    private void SpawnFirstWave()
    {
        GameObject dog = Instantiate(dogEnemy, spawnPoints[0].position, Quaternion.identity);
        Agent dogAgent = dog.GetComponent<Agent>();
        dogAgent.Target = target;
        dogAgent.EnemySpawner = this;
    }

    private void WaveTextUpdate()
    {
        waveText.text = "Wave : " + currentWave.ToString();
    }   
}
