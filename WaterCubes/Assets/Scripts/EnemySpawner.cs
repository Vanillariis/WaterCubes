using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // references to the enemy prefabs
    [SerializeField] private GameObject[] enemyPrefab;

    //bool to make sure an eatable enemy is spawned every second time an enemy is spawned
    private bool instantiatMiniEnemy;
    
    // time between enemy spawns
    private float spawnInterval = 6f; 

    void Start()
    {
        instantiatMiniEnemy = true;
        
        //the SpawnEnemy method is called repeatedly based on the spawnInterval
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {

        // Instantiate a new enemy at a random place within a certain range.
        Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], 
            new Vector3(Random.Range(-4f, 4f),Random.Range(-1f,4f), Random.Range(-4f,4f)), Quaternion.identity);

        if (instantiatMiniEnemy)
        {
            //instantiates the smallest enemy 
            Instantiate(enemyPrefab[0]);
        }
        
        //make sure it instantiates a mini enemy every second time
        instantiatMiniEnemy = !instantiatMiniEnemy;
    }
}

