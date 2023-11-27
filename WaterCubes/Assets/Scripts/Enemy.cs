using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    
    public int sizeAndPointAmount;
    
    // Speed at which the enemy moves
    private float swimSpeed = 2f;

    private Vector3 initVelocity;

    private PlayerScript playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Player script from the player cube
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        
        GameObject player = GameObject.Find("Player");
        playerTransform = player.transform;
        
        // the enemy gets a random initial velocity in the x-z plane
        float randomAngle = Random.Range(0f, 360f);
        initVelocity = Quaternion.Euler(0f, randomAngle, 0f) * Vector3.forward * swimSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        EnemySwim();
        chasePlayer();
    }
    
    public void EnemySwim()
    {
        // Move the enemy forward
        transform.Translate(initVelocity * Time.deltaTime);
    }
    
    // Called when the player cube collides with this cube
    private void OnCollisionEnter (Collision collision)
    {
        // Check if the colliding object is the player cube
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the Player cube is bigger or equal in size
            if (playerScript.playerSize >= sizeAndPointAmount)
            {
                //destroy the enemy
                Destroy(gameObject);
                Debug.Log("Enemy got eaten");
                Debug.Log("Enemy this big:" + sizeAndPointAmount);
                
                //Player can eat this cube
                playerScript.EatCube(sizeAndPointAmount);
                Debug.Log("EatCube was called");
            }
            else
            {
                //enemy eats Player
                SceneManager.LoadScene("YouDiedScene");
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            initVelocity = -initVelocity;
        }
    }

    private void chasePlayer()
    {
        float maxFollowDistance = 10f;
        
        float raycastLength = 5;
        Ray ray = new Ray(transform.position, initVelocity);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,raycastLength))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (playerScript.playerSize <= sizeAndPointAmount)
                {
                    float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

                    if (distanceToPlayer <= maxFollowDistance)
                    {
                        //the direction towards the player
                        Vector3 directionToPlayer = (playerTransform.position).normalized;

                        //adjust the movement direction to follow the player
                        initVelocity = directionToPlayer * swimSpeed;

                        //move towards the player
                        transform.Translate(initVelocity * Time.deltaTime); 
                    }
                }
            }
        }
    }
}

