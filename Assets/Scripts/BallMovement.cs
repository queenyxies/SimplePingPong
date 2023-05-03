using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
    public float startSpeed; //Determine starting speed of ball
    public float extraSpeed;  //How much speed will the ball is going to increase everytime it bounces it bounces off the racket
    public float maxExtraSpeed; //Determine max extra speed for the ball. Para hindi mag increase yung speed ng ball

    private int hitCounter = 0;

    private Rigidbody2D rb; //Use physics to move the ball
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Fetch rigidbody2D from Ball game obj
        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        hitCounter = 0;
        yield return new WaitForSeconds(1);


        MoveBall(new Vector2(-1, 0));
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed; //Determine current speed of ball. Able to increase speed of ball continuously 

        rb.velocity = direction * ballSpeed;
    }

    public void IcreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

}
