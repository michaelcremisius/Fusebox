using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FrogBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 StartingPoint;
    public Text scoreBoard;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement()
    {
        rb2d.velocity = new Vector3(7, 0, 0);
    }
    public void StopMovement()
    {
        rb2d.velocity = new Vector3(0, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {
            score++;
            scoreBoard.text = score.ToString();
        }
        transform.position = StartingPoint;

    }
}
