using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class attackScript : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    public GameObject Player;
    float beforeFallCounter = 0.5f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
       if (col.gameObject.tag =="attack")  
        {
                anim.SetBool("attacked", true);

                if (beforeFallCounter > 0) 
                {
                    beforeFallCounter -= Time.deltaTime;
                }
                else if (beforeFallCounter <= 0) 
                {
                    rb.gravityScale = 2.5f;
                }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        anim.SetBool("attacked", false);
    }
}
