using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassPlayer : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bassBulletPrefab;
    
    public Animator shootAnimator;

    private int counter = 0;
    private static float PAUSE_TIME = 0.15f;
    private float currTime = 0.0f;
    private static int LINE_SIZE = 16;
    bool[] bassLine = { false, false, false, false,
                        false, false, false, false,
                        false, false, false, false,
                        false, false, false, false };

    private void Start()
    {
        generateBassLine();
    }

    private void Update()
    {
        currTime += Time.deltaTime;
        if (currTime >= PAUSE_TIME)
        {
            PlayBass();
            currTime = 0.0f;
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
            Instantiate(bassBulletPrefab, shootPoint.position, shootPoint.rotation);
            shootAnimator.SetTrigger("Shoot");
        }        
        counter++;      
    }    

    private void generateBassLine()
    {
        for (int i = 0; i < LINE_SIZE; i++)
        {
            bassLine[i] = Random.value >= 0.5 ? true : false;
        }
    }
}
