using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class hatShooterMovement : MonoBehaviour
{
    public Rigidbody2D hatShooterRB;

    private Vector2 velocity = new Vector2(1.0f, 0.0f);
    private float corr = Screen.width / 4;
    private float speed = Screen.width / 7;

    void Update()
    {
        if (Starter.started)
        {
            if (velocity.x == 0.0f)
            {
                velocity.x = 1.0f;
            }
            if (velocity.x == 1.0f && hatShooterRB.position.x > Screen.width - corr)
            {
                velocity = new Vector2(-1.0f, 0.0f);
            }
            else if (velocity.x == -1.0f && hatShooterRB.position.x < -Screen.width + corr)
            {
                velocity = new Vector2(1.0f, 0.0f);
            }
        }
        else
        {
            velocity = new Vector2(0.0f, 0.0f);
        }
    }

    void FixedUpdate()
    {
        moveHatShooter(velocity);
    }

    void moveHatShooter(Vector2 direction)
    {
        hatShooterRB.MovePosition(hatShooterRB.position + (direction * speed * Time.deltaTime));
    }
}
