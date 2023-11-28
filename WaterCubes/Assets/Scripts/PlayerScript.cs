using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    
    //Mouse variables:
    private float sensitivityX = 400f;
    private float sensitivityY = 400f;

    private float xRotation;
    private float yRotation;
    
    //Movement Variables:
    private Rigidbody playerRB;
    private float swimSpeed = 15f;
    private Vector3 moveDirection;
    
    //Player variables
    public int playerSize;
    private Vector3 currentScale;
    private Queue<int> levelUP = new Queue<int>();

    //UI variables
    public Text level;
    public Text point;
    private int score;
    private int levelCount;
    private int pointToNextLevel;

    // Start is called before the first frame update
    void Start()
    {
        //locking the curser so it doesn´t move around the screen while we look around and make it invisisble 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;

        score = 0;
        playerSize = 1;
        
        //levelUP numbers
        levelUP.Enqueue(5);
        levelUP.Enqueue(10);
        levelUP.Enqueue(15);
        levelUP.Enqueue(20);
        levelUP.Enqueue(25);
        pointToNextLevel = levelUP.Dequeue();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerSwim();
        PlayerLook();
    }
    
    private void PlayerSwim()
    {
        // return values between -1 and 1 based on the player's input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //ensures that the player always move in the direction we look
        moveDirection = gameObject.transform.forward * verticalInput + gameObject.transform.right * horizontalInput;
        
        //add force to the player so it  moves
        //"narmalized" ensures that the player moves at a consistent speed in all directions
        //by making sure the total length of the movement vector is always 1.
        playerRB.AddForce(moveDirection.normalized * swimSpeed);
        
        // Limit the player's speed 
        if (playerRB.velocity.magnitude > swimSpeed)
        {
            playerRB.velocity = playerRB.velocity.normalized * swimSpeed;
        }
        
        // Check if the space button is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            // Apply additional force upward
            playerRB.AddForce(Vector3.up * 5f);
        }
        else
        {
            // Apply force downward to simulate gravity
            playerRB.AddForce(Vector3.down * 3f);
        }
    }
    
    
    private void PlayerLook()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;
        
        //set rotation (this is how unity handles rotations)
        yRotation += mouseX;
        xRotation -= mouseY;
        
        //making sure we can look up/down more than 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        
        //using Quaternion.Euler to handle rotation along the x and y axis.
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
    
    //called from the enemy scripts when the player collides with an enemy smaller or equal in size
    public void EatCube(int enemyPoint)
    {
        //updating the score and UI text for score
        score += enemyPoint;
        point.text = "Point:" + score;

        //check if  the player has won and of not check if the player  as reached the score amount that takes them to the next level.
        if (score >= 25)
        {
            SceneManager.LoadScene("YouWonScene");
        }
        else if(score >= pointToNextLevel)
        {
            Grow();
            score = 0;
            point.text = "Point:" + score;
            pointToNextLevel = levelUP.Dequeue(); 
        }
    }

    //called when the player goes to the next level
    private void Grow()
    {
        //updating the playerSize and UI text for level
        playerSize++;
        level.text = "Level:" + playerSize;
        //make the player grow/scale up
        transform.localScale =
            Vector3.Lerp(transform.localScale, transform.localScale + new Vector3(0.25f, 0.25f, 0.25f), 6f);
    }
}
