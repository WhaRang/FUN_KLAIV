using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    int highscore;

    public static HighScoreManager manager;

    private void Awake()
    {
        if (manager == null)
            manager = this.gameObject.GetComponent<HighScoreManager>();
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    private void Update()
    {
        if (highscore < CoinManager.getCoins())
        {
            highscore = CoinManager.getCoins();
        }
    }

    public int GetHighScore()
    {
        return highscore;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
    }
}
