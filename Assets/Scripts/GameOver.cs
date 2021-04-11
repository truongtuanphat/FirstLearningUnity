using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text finishScore;

    void Start()
    {
        if (finishScore != null) 
            finishScore.text = PlayerPrefs.GetString("FinishScore");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
