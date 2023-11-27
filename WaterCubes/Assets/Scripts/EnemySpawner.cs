using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // references to the enemy prefabs
    [SerializeField] private GameObject[] enemyPrefab;

    private bool instantiatMiniEnemy;
    
    private float spawnInterval = 6f; // time between enemy spawns

    void Start()
    {
        instantiatMiniEnemy = true;
        
        //the SpawnEnemy method is called repeatedly based on the spawnInterval
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {

        // Instantiate a new enemy at the spawner's position and rotation
        Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], 
            new Vector3(Random.Range(-4f, 4f),Random.Range(-1f,4f), Random.Range(-4f,4f)), Quaternion.identity);

        if (instantiatMiniEnemy)
        {
            Instantiate(enemyPrefab[0]);
        }
        
        //make sure it instantiates a mini enemy every second time
        instantiatMiniEnemy = !instantiatMiniEnemy;
    }
}

