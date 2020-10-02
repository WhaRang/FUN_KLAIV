using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CoinBehaviour : MonoBehaviour
{

    private float despawnTime = 7.0f;

    void Start()
    {
        StartCoroutine(despawnCoinCorountine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("CoinPickUp");
            CoinManager.AddCoin();
            despawnCoin();
        }
    }

    private void despawnCoin()
    {
        Destroy(this.gameObject);
    }

    IEnumerator despawnCoinCorountine()
    {
        while(true)
        {
            yield return new WaitForSeconds(despawnTime);
            CoinManager.RemoveCoin();
            despawnCoin();
            FindObjectOfType<AudioManager>().Play("CoinLoose");
        }
    }
}
