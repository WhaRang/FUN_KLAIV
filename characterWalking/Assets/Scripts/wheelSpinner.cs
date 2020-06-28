using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelSpinner : MonoBehaviour
{
    public GameObject wheel;
    public Rigidbody2D rb;

    public float scaler = 10.0f;
    
    void Update()
    {
        wheel.transform.Rotate(0.0f, 0.0f, -rb.velocity.y / scaler);
        wheel.transform.Rotate(0.0f, 0.0f, -rb.velocity.x / scaler);
    }
}
