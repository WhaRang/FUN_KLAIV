using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bassShooterMovement : MonoBehaviour
{

    public Rigidbody2D followedRB;
    public Rigidbody2D bassShooterRB;

    private static float CORR = 300.0f;

    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    private float speed = 0.0f;
    private float maxSpeed = 1000.0f;
    private float farDistance = 100.0f;

    void Update()
    {
        if (followedRB != null)
        {
            float followedPoint = 0.0f;
            if (velocity.y == 0.0f)
            {
                if (followedRB.position.y < bassShooterRB.position.y)
                {
                    velocity.y = 1.0f;
                }
                else
                {
                    velocity.y = -1.0f;
                }
            }            
            if (velocity.y == 1.0)
            {
                followedPoint = followedRB.position.y + CORR;
                if (bassShooterRB.position.y > followedPoint)
                {
                    velocity.y = -1.0f;
                }
            }
            else
            {
                followedPoint = followedRB.position.y - CORR;
                if (bassShooterRB.position.y < followedPoint)
                {
                    velocity.y = 1.0f;
                }
            }
            speed = (Math.Abs(followedPoint - bassShooterRB.position.y) / farDistance) * maxSpeed;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
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
        bassShooterRB.velocity = speed * direction;
    }
}
