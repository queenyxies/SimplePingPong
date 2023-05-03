using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement1 : MonoBehaviour
{
    //Serialize para maedit sa inspector view
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text PlayerScore;
    [SerializeField] private Text AIScore;

    private int hitCounter;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 3f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter)); //To make speed of ball constant kahit tumama
    }

    //Start of each round. Initialize the direction for the ball to go into
    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter); //To move towards player
    }

    //Called at the end of each round. Put ball back to center, remove velocity, and invoke start ball function
    private void ResetBall()
    {
        //NO speed or anything
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        //Reset score
        hitCounter = 0;
        Invoke("StartBall", 3f); //Call this function after 3 seconds of this line being run. Give player preparation for next round
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;

        Vector2 ballPos = transform.position; //equal the transform.post=ition
        Vector2 playerPos = myObject.position;

        //to make ball take different direction
        float xDirection, yDirection;
        //if x position of bsll is on the right we have to flip the x direction kaya -1 para move sa left
        if(transform.position.x > 0)
        {
            xDirection = -1;
        }
        else 
        {
            xDirection = 1;
        }
        //yDirection = (ballPos.y - ballPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        yDirection = Random.Range(-1, 1);
        if(yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
        }
    }

    //Scoring
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x > 0)
        {
            ResetBall();
            PlayerScore.text = (int.Parse(PlayerScore.text) + 1).ToString();
        }
        else if(transform.position.x < 0)
        {
            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }
}
