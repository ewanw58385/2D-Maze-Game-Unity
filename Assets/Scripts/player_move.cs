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
            anim.SetFloat("speed", xSpeed);                        
        }

        if (Input.GetKey("d"))
        {
            // registers a key held down and returns true
            xSpeed = 6f;
            anim.SetFloat("speed", xSpeed);
        } 

        if (Input.GetKey("s"))
        {
            ySpeed = -6f;
            anim.SetFloat("speed", ySpeed);
        }

        if (Input.GetKey("w"))
        {
            ySpeed = 6f;
            anim.SetFloat("speed", ySpeed);
        }
        
        transform.position += new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
    }
    
}
