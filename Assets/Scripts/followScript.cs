using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 4f;
    public float counter = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            if (counter < 500f)
        {
            Debug.Log(counter);
            counter ++;
            transform.localScale = new Vector3 (0f, 1f, 0f);
            //GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.x);
            GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
        }
            else if (counter == 500f)
        {
            Debug.Log(counter);
            counter --;
            transform.localScale = new Vector3 (0f, -1f, 0f);
            //GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.x);
            GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        //while (counter < 500f)
        //{
       // Debug.Log(counter);
       // counter --;
       // transform.localScale = new Vector3 (0f, -1f, 0f);
        //GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.x);
       // GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
        //}
    }
}
