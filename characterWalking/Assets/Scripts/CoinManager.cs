using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinTF;
    private static int coins = 0;

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
        coinTF.text = coins.ToString();
    }

    public static int getCoins()
    {
        return coins;
    }
}
