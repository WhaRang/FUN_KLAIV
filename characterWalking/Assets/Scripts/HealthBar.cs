using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int health;
    private int maxHealth;

    public Animator hbAnimator;

    public Heart heart1;
    public Heart heart2;
    public Heart heart3;

    public void SetHealthSettings(int _health)
    {
        health = _health;
        maxHealth = _health;
    }

    public void decrementHealth()
    {
        health--;
        switch(maxHealth - health)
        {
            case 1:
                {
                    hbAnimator.SetTrigger("Shake");
                    heart1.CutHeart();
                    break;
                }
            case 2:
                {
                    hbAnimator.SetTrigger("Shake");
                    heart1.DestroyHeart();
                    break;
                }
            case 3:
                {
                    hbAnimator.SetTrigger("Shake");
                    heart2.CutHeart();
                    break;
                }
            case 4:
                {
                    hbAnimator.SetTrigger("Shake");
                    heart2.DestroyHeart();
                    break;
                }
            case 5:
                {
                    hbAnimator.SetTrigger("Shake");
                    heart3.CutHeart();
                    break;
                }
            case 6:
                {
                    hbAnimator.SetTrigger("Shake");
                    heart3.DestroyHeart();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
