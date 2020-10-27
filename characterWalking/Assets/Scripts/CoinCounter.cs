using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text textField;
    int coins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        coins += CoinManager.getCoins();
    }

    private void Update()
    {
        textField.text = "" + coins;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.Save();
    }
}
