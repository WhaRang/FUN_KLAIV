using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    private static int MAX_HEALTH = 6;
    private int health;

    public HealthBar hb;
    public GameEnder gameEnder;

    private void Start()
    {
        hb.SetHealthSettings(MAX_HEALTH);
        health = MAX_HEALTH;
    }
    public void TakeDamage()
    {
        hb.decrementHealth();
        playerAnimator.SetTrigger("Hit");
        FindObjectOfType<AudioManager>().Play("Punch");        
        DecrementHealth();
    }

    private void DecrementHealth()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Starter.started = false;
        Destroy(gameObject);
        gameEnder.endGame();
    }

}
