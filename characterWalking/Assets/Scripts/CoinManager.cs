using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinTF;
    private static float coins = 0.0f;

    public static void AddCoin()
    {
        coins++;
    }

    public static void RemoveCoin()
    {
        coins--;
    }

    private void Update()
    {
        coinTF.text = "COINS: " + coins.ToString();
    }
}
