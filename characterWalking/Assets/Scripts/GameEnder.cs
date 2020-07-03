using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    public Animator gameEndAnimator;
    private float transitionTime = 2f;

    public void endGame()
    {
        StartCoroutine(loadGameEnd());
    }

    IEnumerator loadGameEnd()
    {
        gameEndAnimator.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        if (SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}