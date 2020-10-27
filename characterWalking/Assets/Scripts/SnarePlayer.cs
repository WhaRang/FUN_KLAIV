using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnarePlayer : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject snareBulletPrefab;

    public Animator shootAnimator;

    private int counter = 0;
    private static float PAUSE_TIME = 0.20f;
    private float currTime = 0.0f;

    private static int TACT_SIZE = 4;
    private static int LINE_SIZE = 16;
    // 0.0 to 1.0
    private static float SNARE_FREQUENCY = 0.7f;

    bool[] snareLine = { false, false, true, false,
                         false, false, false, false,
                         false, false, true, false,
                         false, false, false, false, };
    private void Update()
    {
        if (Starter.started)
        {
            currTime += Time.deltaTime;
            if (currTime >= PAUSE_TIME)
            {
                PlaySnare();
                currTime = 0.0f;
            }
        }
    }

    private void PlaySnare()
    {
        if (counter >= LINE_SIZE)
        {
            counter = 0;
        }
        if (snareLine[counter])
        {
            FindObjectOfType<AudioManager>().Play("Snare");
            Instantiate(snareBulletPrefab, shootPoint.position, shootPoint.rotation);
            shootAnimator.SetTrigger("Shoot");
        }
        counter++;
    }

    private void Start()
    {
        generateSnareLine();
    }

    private void generateSnareLine()
    {
        for (int i = LINE_SIZE - TACT_SIZE; i < LINE_SIZE; i++)
        {
            snareLine[i] = Random.value >= (1 - SNARE_FREQUENCY) ? true : false;
        }
    }
}
