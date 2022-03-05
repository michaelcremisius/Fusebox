using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject obstacle;
    private int direction;
    private Rigidbody2D rb2d;
    private float switchTimer;
    private float obstacleTimer;
    private float cooldownTimer;
    private Vector3 startPos;
    public GameObject Player;
    private void Start()
    { 
        switchTimer = .25f;
        obstacleTimer = 1f;
        direction = 1;
        cooldownTimer = 1f;
        startPos = transform.position;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<PlayerBehaviour>().score < Player.GetComponent<PlayerBehaviour>().threshold)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                CreateObstacle();
            }
        }

    }
    private void FixedUpdate()
    {
        if (Player.GetComponent<PlayerBehaviour>().score < Player.GetComponent<PlayerBehaviour>().threshold)
        {
            if (cooldownTimer <= 0)
            {
                Movement();
            }
        }
        else
        {
            rb2d.velocity = new Vector3(0, 0, 0);
        }
    }
    public void InitiateCooldown()
    {
        cooldownTimer = 2f;
        rb2d.velocity = Vector3.zero;
        transform.position = startPos;
    }


    private void CreateObstacle()
    {
        obstacleTimer -= Time.deltaTime;
        if(obstacleTimer <= 0)
        {
            Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.identity);
            obstacleTimer = 1f;
        }
    }



    private void Movement()
    {

        int switchNum = Random.Range(1, 4);

        switchTimer -= Time.deltaTime;
        if(switchTimer <= 0)
        {
            if (switchNum == 1)
            {
                direction = -direction;
            }
            switchTimer = .25f;
        }
        rb2d.velocity = new Vector3(Random.Range(3,5) * direction,0,0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Bound"))
        {
            direction = -direction;
        }
    }
}
