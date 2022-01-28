using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogObstacleBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private float xValue;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        xValue = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //bounds are 7 and -7
        rb2d.velocity = new Vector3(0, speed, 0);
        if(transform.position.y > 7)
        {
            transform.position = new Vector3(xValue, -7, 0);
        }
    }
}
