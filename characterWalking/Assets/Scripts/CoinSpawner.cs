using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coinPrefab;
    private Vector2 screenBounds;
    private Vector2 newPosition;

    private int A = -1800;
    private int B = 1500;
    private int C = -400;
    private int D = 600;

    private int E = -980;
    private int F = 1300;
    private int G = -1300;


    private int defSize = 300;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height, Camera.main.transform.position.z));
    }


    public void SpawnCoin()
    {
        Starter.started = true;
        GameObject obj = Instantiate(coinPrefab) as GameObject;
        newPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x),
            Random.Range(-screenBounds.y, screenBounds.y));
        if (!CheckNewPosition(newPosition))
        {
            newPosition = new Vector2(Random.Range(-defSize, defSize),
            Random.Range(-defSize, defSize));            
        }
        obj.transform.position = newPosition;
    }


    private bool CheckNewPosition(Vector2 newPosition)
    {
        return (CheckPos1(newPosition) || CheckPos2(newPosition));
    }


    private bool CheckPos1(Vector2 newPosition)
    {
        return (newPosition.y < C) && (newPosition.y > E) && (newPosition.x < F) && (newPosition.x > G);
    }


    private bool CheckPos2(Vector2 newPosition)
    {
        return (newPosition.x < B) && (newPosition.x > A) && (newPosition.y < D) && (newPosition.y > C);
    }


    public void onPress()
    {
        FindObjectOfType<AudioManager>().Play("CoinButtonPress");
        SpawnCoin();
    }
}
