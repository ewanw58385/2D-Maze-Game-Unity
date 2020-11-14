using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private Vector3 previousLocation;
    private Vector2 PlayerPos; 
    private bool touchingWall;
    public float velocity;
    private float wallTimer = 1.5f;
    
     void Start()
    {
        anim = GetComponent<Animator>();
        previousLocation = transform.position; /*sets a vector3 varible to starting position of enemy sprite. called in start  method for initial position, 
                                                 varible is called previouspos bc it gets called in update method. */
    }
    
    void Update()
    {
       flipPlayerSprite(); //calls the flip method each frame
       PlayerPos = (GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);

    }

    private void flipPlayerSprite() //method for detecting velocity direction on X axis
    {
        Vector3 currentVelocity = (transform.position - previousLocation) / Time.deltaTime; //Current vel = ((current position) - last known location) / time
        if(currentVelocity.x != 0) //prevents sprite flipping when velocity direction is unobtainable
        {
            if (currentVelocity.x > 0) //moving left; negative X vel
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0); //flip when left
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0); // "" right
            }
        }           
        previousLocation = transform.position; //keeps previous location updated every frame
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "walls") //if hit enemy runs into wall while following player:
        {
            touchingWall = true;        
        }    
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "walls") //if hit enemy runs into wall while following player:
        {
            touchingWall = false;        
        }
    }

    void OnTriggerStay2D(Collider2D col) //enemies collider method
    {
        if (col.gameObject.tag == "walls") //if hit enemy runs into wall while following player:
        {
            wallCollisonDetection(); //set bool detection to true         
        }
        else
        {
            wallCollisonDetection(); //"" false
        }      
        if (col.gameObject.tag == "Player") //if runs into player radius 
        {
            moveWhenInPlayerRadius(); //call moveWheninradius method 
        }
    }

    private void wallCollisonDetection() //method for changing animation if sprite is touching a wall
    {
        if(touchingWall) //(is true)
        {
            anim.SetBool("touchingWall", true);
        }
        else
        {
            anim.SetBool("touchingWall", false);
        }
    }

    private void moveWhenInPlayerRadius() //method for following the player
    {
        if((touchingWall) || (wallTimer < 0.5)) //both start as false. If player touches a wall, starts timer in if statement + move enemy in opposite direction for duration of timer.
        {
                transform.position = Vector2.MoveTowards(transform.position, transform.InverseTransformDirection(PlayerPos), velocity * Time.deltaTime); //move away from player

                if(wallTimer > 0) //starts as 1.5, by default is true: increment timer negativelly.
                {
                    wallTimer -= Time.deltaTime;
                }
                else if(wallTimer <= 0) //once timer ends, resets back to 4, so else statement is initialized and enemy returns to following.
                {
                    wallTimer = 0.5f;
                }
        }
        else 
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos, velocity * Time.deltaTime); //Follows the player using .MoveTowards
            wallTimer = 0.5f; //ensures timer stays as 1.5 until touchedwall = true. 
        }
        
    } 
}