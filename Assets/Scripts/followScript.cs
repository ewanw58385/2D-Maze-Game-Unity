using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{

    public Rigidbody2D rb;
    private Vector2 velocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(9f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 180f, 0);
    }
}
