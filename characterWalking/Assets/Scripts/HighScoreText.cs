using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    public Text textField;

    void Update()
    {
        textField.text = "HIGHSCORE: " + HighScoreManager.manager.GetHighScore();   
    }
}
