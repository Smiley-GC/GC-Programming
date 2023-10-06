using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject ball;
    public float speed = 0.0f;
    // We want the ball to change directions when it hits our paddle

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float dir = 0.0f;
        if (Input.GetKey(KeyCode.W))
        {
            dir = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir = -1.0f;
        }
        float dy = speed * dir * dt;
        transform.position = transform.position + new Vector3(0.0f, dy, 0.0f);

        // How to control one object with another:
        //ball.transform.position = new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z);
        
        // gameObject is the current object, so gameObject = Paddle in this script!
        if (Collision.Overlap2D(gameObject, ball))
        {
            // *= explanation:
            //float a = 1.0f;
            //a = a * 2.0f;
            //a *= 2.0f;
            // The above two lines are identical in behaviour
            Ball ballData = ball.GetComponent<Ball>();
            ballData.xDir *= -1.0f;

            // Homework: modify this script such that
            // if the ball collides with the top half of the paddle, move the ball up
            // if the ball collides with the bottom half of the paddle, move the ball down
            // (You shouldn't need to change anything outside of this paddle-ball collision check block)
        }
    }
}
