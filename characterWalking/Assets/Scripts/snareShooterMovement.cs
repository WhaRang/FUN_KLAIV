using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class snareShooterMovement : MonoBehaviour
{

    public Rigidbody2D followedRB;
    public Rigidbody2D snareShooterRB;

    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    private float speed = 0.0f;
    private float maxSpeed = 500.0f;
    private float farDistance = 1500.0f;

    void Update()
    {
        speed = (Math.Abs(followedRB.position.y - snareShooterRB.position.y) / farDistance) * maxSpeed;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        if (followedRB.position.y > snareShooterRB.position.y)
        {
            velocity = new Vector2(0.0f, 1.0f);
        }
        else
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
        snareShooterRB.velocity = speed * direction;
    }
}
