using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bassShooterMovement : MonoBehaviour
{

    public Rigidbody2D followedRB;
    public Rigidbody2D bassShooterRB;

    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    private float speed = 0.0f;
    private float maxSpeed = 1000.0f;
    private float farDistance = 1000.0f;

    void Update()
    {
        speed = (Math.Abs(followedRB.position.y - bassShooterRB.position.y) / farDistance) * maxSpeed;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        if (followedRB.position.y > bassShooterRB.position.y)
        {
            velocity = new Vector2(0.0f, 1.0f);
        } else
        {
            velocity = new Vector2(0.0f, -1.0f);
        }
    }

    void FixedUpdate()
    {
        moveObject(velocity);
    }

    void moveObject(Vector2 direction)
    {
        bassShooterRB.velocity = speed * direction;
    }
}
