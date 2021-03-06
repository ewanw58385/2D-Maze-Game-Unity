﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class attackScript : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    private Animator playerAnim;
    public GameObject Player;
    public float timeBeforeFallCounter = 0.25f;
    private float deathThrust = 800f;  
    bool previousAttacked = false; 
    public Vector2 deathPos;     

    void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = Player.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D col) 
    {
       if ((col.gameObject.tag =="attack") && (previousAttacked == false))
        {
                anim.SetBool("attacked", true);

                if (timeBeforeFallCounter > 0) //stops player falling off map before attack anim has time to finish
                {
                    timeBeforeFallCounter -= Time.deltaTime;
                }
                else if (timeBeforeFallCounter <= 0) 
                {
                    rb.gravityScale = 2.5f;
                    Player.GetComponent<Collider2D>().isTrigger = true; //disables box colliders for player 
                    playerAnim.SetBool("dead", true);
                    rb.AddForce(transform.up * deathThrust);
                    previousAttacked = true;
                }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        anim.SetBool("attacked", false);
        anim.SetBool("touchingWall", true); //prevents from transitioning to run anim when player killed
        Vector2 deathPos = GameObject.Find("Player").transform.position;
    }
}
