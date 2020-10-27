using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatPlayer : MonoBehaviour
{
    public Transform leftShootPoint;
    public Transform rightShootPoint;
    public GameObject hatBulletPrefab;

    public Animator shootAnimator;

    private bool left = true;

    private int counter = 0;
    private static float PAUSE_TIME = 0.20f;
    private float currTime = 0.0f;
    private static int LINE_SIZE = 16;
    bool[] hatLine =  { true, false, true, false,
                        true, false, true, false,
                        true, false, true, false,
                        true, false, true, false };
    private void Update()
    {
        if (Starter.started)
        {
            currTime += Time.deltaTime;
            if (currTime >= PAUSE_TIME)
            {
                PlayHat();
                currTime = 0.0f;
            }
        }
    }

    private void PlayHat()
    {
        if (counter >= LINE_SIZE)
        {
            counter = 0;
        }
        if (hatLine[counter])
        {
            
            if (left)
            {
                shootAnimator.SetTrigger("Left");
                FindObjectOfType<AudioManager>().Play("Hat");
                Instantiate(hatBulletPrefab, leftShootPoint.position, leftShootPoint.rotation);
                left = false;
            }
            else
            {
                shootAnimator.SetTrigger("Right");
                FindObjectOfType<AudioManager>().Play("Hat");
                Instantiate(hatBulletPrefab, rightShootPoint.position, rightShootPoint.rotation);
                left = true;
            }
        }
        counter++;
    }
}
