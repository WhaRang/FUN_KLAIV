using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassPlayer : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bassBulletPrefab;

    private static int LINE_SIZE = 32;
    private static float PAUSE_TIME = 0.20f;
    private static float RARE_BASS = 0.3f;
    private static float FREQUENT_BASS = 0.5f;

    public Animator shootAnimator;
    private int counter = 0;    
    private float currTime = 0.0f;

    bool[] bassLine = new bool[LINE_SIZE];

    private void Start()
    {
        generateBassLine();
    }

    private void Update()
    {
        if (Starter.started)
        {
            currTime += Time.deltaTime;
            if (currTime >= PAUSE_TIME)
            {
                PlayBass();
                currTime = 0.0f;
            }
        }
    }

    private void PlayBass()
    {
        if (counter >= LINE_SIZE)
        {
            counter = 0;
        }
        if (bassLine[counter])
        {
            FindObjectOfType<AudioManager>().Play("Bass");
            Instantiate(bassBulletPrefab, shootPoint.position, shootPoint.rotation);
            shootAnimator.SetTrigger("Shoot");
        }        
        counter++;      
    }    

    private void generateBassLine()
    {
        for (int i = 0; i < LINE_SIZE / 2; i++)
        {
            bassLine[i] = Random.value <= RARE_BASS ? true : false;
        }
        for (int i = LINE_SIZE / 2; i < LINE_SIZE; i++)
        {
            bassLine[i] = Random.value <= FREQUENT_BASS ? true : false;
        }
    }
}
