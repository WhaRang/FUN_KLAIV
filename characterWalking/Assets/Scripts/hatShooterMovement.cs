using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class hatShooterMovement : MonoBehaviour
{

    public Rigidbody2D followedRB;
    public Rigidbody2D hatShooterRB;

    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    private float speed = 0.0f;
    private float maxSpeed = 2000.0f;
    private float farDistance = 2000.0f;

    void Update()
    {
        if (followedRB != null)
        {
            speed = (Math.Abs(followedRB.position.x - hatShooterRB.position.x) / farDistance) * maxSpeed;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            if (followedRB.position.x > hatShooterRB.position.x)
            {
                velocity = new Vector2(1.0f, 0.0f);
            }
            else
            {
                velocity = new Vector2(-1.0f, 0.0f);
            }
        }
        else
        {
            velocity = new Vector2(0.0f, 0.0f);
        }
    }

    void FixedUpdate()
    {
        moveObject(velocity);
    }

    void moveObject(Vector2 direction)
    {
        hatShooterRB.velocity = speed * direction;
    }
}
