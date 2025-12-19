using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnedEnemy;
    [SerializeField] private float spawnCountdown;

    [SerializeField] private int maxSpawns;

    private int spawnedCount;

    void Start()
    {
        spawnedCount = 0;
    }

    void Update()
    {
        if (spawnedCount >= maxSpawns)
        {
            enabled = false; 
            return;
        }

        if (spawnCountdown > 0)
        {
            spawnCountdown -= Time.deltaTime;
        }

        if (spawnCountdown <= 0)
        {
            Instantiate(spawnedEnemy, transform.position, transform.rotation);
            spawnedCount++;

           
            
        }
    }
}
