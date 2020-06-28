using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnareBullet : MonoBehaviour
{
    private float speed = 500.0f;
    private static float CORRECTION = 200f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
        FindObjectOfType<AudioManager>().Play("Snare");
    }

    void Update()
    {
        if (rb.position.x <= -(Screen.width + CORRECTION))
        {
            Destroy(gameObject);
        }
    }
}
