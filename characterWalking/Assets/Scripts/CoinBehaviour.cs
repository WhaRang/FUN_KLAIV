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
        StartCoroutine(DespawnCoinCorountine());
    }

    private void Update()
    {
        if (GameEnder.ender.IsEnded())
        {
            RemoveCoin();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("CoinPickUp");
            CoinManager.AddCoin();
            DespawnCoin();
        }
    }

    private void DespawnCoin()
    {
        Destroy(this.gameObject);
    }

    private void RemoveCoin()
    {
        CoinManager.RemoveCoin();
        DespawnCoin();
        FindObjectOfType<AudioManager>().Play("CoinLoose");
    }

    IEnumerator DespawnCoinCorountine()
    {
        while(true)
        {
            yield return new WaitForSeconds(despawnTime);
            RemoveCoin();
        }
    }
}
