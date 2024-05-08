using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float speed = 15f;
    float turnspeed = 300f;
    float gravity_speed = -9.8f;
    Vector3 obstacle_Velocity;
    Rigidbody obstacleRb;

    public bool is_Stone;

    private void Start()
    {
        obstacleRb = GetComponent<Rigidbody>();
        obstacle_Velocity = new Vector3(0, gravity_speed, -speed);
    }

    private void FixedUpdate()
    {
        Obstacle_Move();
    }

    private void Update()
    {
        Obstacle_Destroy();
    }

    void Obstacle_Move()
    {
        obstacleRb.MovePosition(obstacleRb.position + obstacle_Velocity * Time.deltaTime);

        if(is_Stone == true)
        {
            transform.Rotate(-turnspeed* Time.deltaTime, 0, 0);
        }
    }

    void Obstacle_Destroy()
    {
        if(transform.position.z< -20f)
        {
            Destroy(gameObject);
        }
    }
}
