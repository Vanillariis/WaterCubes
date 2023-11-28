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
    
    private float swimSpeed = 2f;

    private Vector3 initVelocity;

    private PlayerScript playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //get the Player script from the player cube
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
    
    //called when the player cube collides with this cube
    private void OnCollisionEnter (Collision collision)
    {
        //check if the colliding object is the player cube
        if (collision.gameObject.CompareTag("Player"))
        {
            //check if the Player cube is bigger or equal in size
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

        //enemy changes direction if it collides with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            initVelocity = -initVelocity;
        }
    }

    private void chasePlayer()
    {
        //if the player is within this distance the enemy will follow it
        float maxFollowDistance = 10f;
        
        //casting a raycast with the length  of 7
        float raycastLength = 7;
        Ray ray = new Ray(transform.position, initVelocity);
        RaycastHit hit;

        //checks if the raycast hits something within the specified length and stores it in the hit 
        if (Physics.Raycast(ray,out hit,raycastLength))
        {
            //chechk if the hit is the player
            if (hit.collider.CompareTag("Player"))
            {
                //chechk if the size of the player is smaller than the enemy
                if (playerScript.playerSize <= sizeAndPointAmount)
                {
                    //gets the distance between the enemy and the player
                    float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

                    //checks the distance to the player is within the maximum distance 
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

