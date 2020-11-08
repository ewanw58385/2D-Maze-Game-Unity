using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed=0;
        float ySpeed=0;

        if (Input.GetKey("a"))
        {
            // registers a key held down and returns true
            xSpeed = -6f;     
            anim.SetFloat("speedright", 0);  
            anim.SetFloat("speedleft", 1);                      
        }

        if (Input.GetKey("d"))
        {
            // registers a key held down and returns true
            xSpeed = 6f;
            anim.SetFloat("speedleft", 0);
            anim.SetFloat("speedright", 1);           
        } 

        if (Input.GetKey("s"))
        {
            ySpeed = -6f;
            anim.SetFloat("speedback", 0);
            anim.SetFloat("speedfor", 1);
        }

        if (Input.GetKey("w"))
        {
            ySpeed = 6f;
            anim.SetFloat("speedback", 1);
            anim.SetFloat("speedfor", 0);
        } 

        if (!Input.anyKey)
        {
            anim.SetFloat("speedleft", 0f);
        }
        if (!Input.anyKey)
        {
            anim.SetFloat("speedright", 0f);
        }
        if (!Input.anyKey)
        {
            anim.SetFloat("speedfor", 0f);
        }
        if (!Input.anyKey)
        {
            anim.SetFloat("speedback", 0f);
        }
        
        transform.position += new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
    }
    
}
