using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private const float DELTA_SPEED = 25.0f;

    private float speed = 0.0f;
    private float maxSpeed = 800.0f;
    private Vector2 movement;

    public Rigidbody2D rb;    
    public Joystick joystick;

    public SpriteRenderer sr;
    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public Animator walkAnimator;

    void Update()
    {
        if (Math.Abs(joystick.Horizontal) > Math.Abs(joystick.Vertical))
        {
            if (speed < maxSpeed)
            {
                speed += DELTA_SPEED;
            }
            if (joystick.Horizontal >= 0.2f)
            {
                Starter.started = true;
                if (movement.x == -1.0)
                {
                    walkAnimator.SetTrigger("Stop");
                    speed = 0.0f;                    
                }
                else if (movement.y != 0)
                {
                    speed /= 2;
                }               
                sr.sprite = rightSprite;
                walkAnimator.SetTrigger("Rotate");
                movement.y = 0f;
                movement.x = 1.0f;
            }
            else if (joystick.Horizontal <= -0.2f)
            {
                Starter.started = true;
                if (movement.x == 1.0)
                {
                    walkAnimator.SetTrigger("Stop");
                    speed = 0.0f;
                }
                else if (movement.y != 0)
                {
                    speed /= 2;
                }                
                sr.sprite = leftSprite;
                walkAnimator.SetTrigger("Rotate");
                movement.y = 0f;
                movement.x = -1.0f;
            }
        }
        else if (Math.Abs(joystick.Horizontal) < Math.Abs(joystick.Vertical))
        {
            if (speed < maxSpeed)
            {
                speed += DELTA_SPEED;
            }
            if (joystick.Vertical >= 0.2f)
            {
                Starter.started = true;
                if (movement.y == -1.0)
                {
                    walkAnimator.SetTrigger("Stop");
                    speed = 0.0f;
                }
                else if (movement.x != 0)
                {
                    speed /= 2;
                }
                sr.sprite = backSprite;
                walkAnimator.SetTrigger("Rotate");
                movement.x = 0f;
                movement.y = 1.0f;
            }
            else if (joystick.Vertical <= -0.2f)
            {
                Starter.started = true;
                if (movement.y == 1.0)
                {
                    walkAnimator.SetTrigger("Stop");
                    speed = 0.0f;
                }
                else if (movement.x != 0)
                {
                    speed /= 2;
                }
                sr.sprite = frontSprite;
                walkAnimator.SetTrigger("Rotate");
                movement.x = 0f;
                movement.y = -1.0f;
            }  
        }
        else if (Math.Abs(speed) < Math.Abs(DELTA_SPEED))
        {
            walkAnimator.SetTrigger("Stop");
            speed = 0;
        }
        else if (speed > 0)
        {
            speed -= DELTA_SPEED;
        }
        else if (speed < 0)
        {
            speed += DELTA_SPEED;
        }
    }

    void FixedUpdate() {        
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direcition)
    {
        rb.MovePosition(rb.position + (direcition * speed * Time.deltaTime));
    }

    public Vector2 getMovement()
    {
        return rb.position + (movement * speed * Time.deltaTime);
    }
}
