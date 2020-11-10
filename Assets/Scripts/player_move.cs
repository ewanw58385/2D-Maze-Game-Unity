using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed=0;
        float ySpeed=0;

        if (Input.GetKey("a")) //left
        {
            // registers a key held down and returns true
            xSpeed = -6f;     
            anim.SetFloat("speedHori", 1);
            anim.SetFloat("speedFor", 0);
            anim.SetFloat("speedBack", 0);
            anim.SetBool("idle", false); //ensures sprite is not idle
            transform.rotation = Quaternion.Euler(0, 180f, 0); //flips the sprite                                
        }

        if (Input.GetKey("d")) //right
        {
            xSpeed = 6f;
            anim.SetFloat("speedHori", 1);
            anim.SetFloat("speedFor", 0); 
            anim.SetFloat("speedBack", 0);  
            anim.SetBool("idle", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);      
        } 

        if (Input.GetKey("s")) //backwards
        {
            ySpeed = -6f;
            anim.SetFloat("speedHori", 0);
            anim.SetFloat("speedFor", 0);
            anim.SetFloat("speedBack", 1);
            anim.SetBool("idle", false);
        }

        if (Input.GetKey("w")) //forwards
        {
            ySpeed = 6f;
            anim.SetFloat("speedHori", 0);
            anim.SetFloat("speedFor", 1);
            anim.SetFloat("speedBack", 0);
            anim.SetBool("idle", false);
        } 

        if (!Input.anyKey)
        {
            anim.SetBool("idle", true);
            anim.SetFloat("speedHori", 0);
            anim.SetFloat("speedFor", 0);
            anim.SetFloat("speedBack", 0);
        }
        
        transform.position += new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
    }
    
}
