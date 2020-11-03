using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    public static GameEnder ender;

    public Animator gameEndAnimator;
    private float transitionTime = 2f;

    public GameObject coinButton;
    public GameObject joystick;

    bool isEnded;

    private void Awake()
    {
        if (ender == null)
            ender = this.gameObject.GetComponent<GameEnder>();
    }

    public void EndGame()
    {
        coinButton.SetActive(false);
        joystick.SetActive(false);
        isEnded = true;
        StartCoroutine(LoadGameEnd());
    }

    IEnumerator LoadGameEnd()
    {
        gameEndAnimator.SetTrigger("End");
        yield return new WaitForSeconds(transitionTime);
        if (SceneManager.GetActiveScene().buildIndex - 1 >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public bool IsEnded()
    {
        return isEnded;
    }
}