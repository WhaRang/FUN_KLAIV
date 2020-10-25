using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTF;

    private void Start()
    {
        scoreTF.text = "SCORE: " + CoinManager.getCoins();
    }
}
