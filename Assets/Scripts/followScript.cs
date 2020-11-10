using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{

    public Component rb;
    public float speed = 4f;
    public float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        do
        {
        Debug.Log(counter);
        counter ++;
        transform.localScale = new Vector3 (1f, 0f, 0f);
        GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.x);
        GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        while (counter > 1000f);
    }
}
