using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocity;
    public Transform playerPos;
    public Animator anim;
    private Vector3 previousLocation;

        void Start()
    {
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //gets position of player for movewheninradious method
        previousLocation = transform.position; /*sets a vector3 varible to starting position of enemy sprite. called in start  method for initial position, 
                                                 varible is called previouspos bc it gets called in update method. */
    }
        void Update()
    {
            flipPlayerSprite(); //calls the flip method each frame 
        }

         void OnTriggerStay2D(Collider2D col) //enemies collider method
        {
            if (col.gameObject.tag == "walls") //if hit enemy runs into wall while following player:
            {
                wallCollisonDetection(true); //set bool detection to true         
            }
            else
            {
                wallCollisonDetection(false); //"" false
            }
        
            if (col.gameObject.tag == "Player")//if runs into player radius,
            {
                moveWhenInPlayerRadius(); //call moveinradius method
            }
        }

        private void wallCollisonDetection(bool touchingWall) //method for changing animation if sprite is touching a wall
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
  
    }

    private void moveWhenInPlayerRadius() //method for following the player
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, velocity * Time.deltaTime); //transform position to follow the player using .MoveTowardds
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