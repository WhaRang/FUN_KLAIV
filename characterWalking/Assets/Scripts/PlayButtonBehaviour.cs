using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehaviour : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    public void PlayGame()
    {        
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        if (SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
