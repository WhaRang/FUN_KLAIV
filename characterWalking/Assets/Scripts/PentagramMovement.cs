using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagramMovement : MonoBehaviour
{
    private static float MOVEMENT_COEF = 0.15f;
    public Rigidbody2D rb;
    public playerMovement pm;

    private void FixedUpdate()
    {
        if (pm != null)
        {
            rb.MovePosition(pm.getMovement() * MOVEMENT_COEF);
        }
    }
}
