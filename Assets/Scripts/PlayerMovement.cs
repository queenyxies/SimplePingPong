using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Seroalize keyword- we can edit these private variables in our editor but also means other scripts can't access them bec. it's private
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball; //Used by the AI-This allow AI to move in correspondence to the ball that in can counter it

    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //AI Control
        if (isAI)
        {
            AIControl();
        }
        //Player Control
        else 
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        //x=0 because we don't want it to move along the x axis
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        //need to know position of ball to know if AI is going up or down
              //ball----------------------------AI
        if (ball.transform.position.y > transform.position.y + 0.5f) //0.5 para hindi too precise
        {
            playerMove = new Vector2(0, 1); //1 because we want to move up
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            //Don't move if katapat ma
            playerMove = new Vector2(0, 0);
        }
            
    }

    private void FixedUpdate() 
    {
        //not be dependent of the player's frame rate - people with higher or lower fps
        rb.velocity = playerMove * movementSpeed;
    }
}
