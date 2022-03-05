using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogObstacleBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private float yValue;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        yValue = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(Player.GetComponent<FrogBehaviour>().score < Player.GetComponent<FrogBehaviour>().threshold)
        {
            print(rb2d.velocity.x);
            rb2d.velocity = new Vector3(speed, 0, 0);
            if (transform.position.x > 7)
            {
                transform.position = new Vector3(-7, yValue, 0);
            }

        }
        else
        {
            rb2d.velocity = new Vector3(0, 0, 0);
        }
    }
}
