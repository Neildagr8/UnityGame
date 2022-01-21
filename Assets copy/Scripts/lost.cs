using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lost : MonoBehaviour
{
    public Text HighScore;
    public static int lives = 3;
    public static int score = 0;
    public static int ques = 0;

    public void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void yup()
    {
        
        lives = 3;
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.Save();

        score = 0;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();

        ques = 0;
        PlayerPrefs.SetInt("ques", ques);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Clock");
    }
    public void oyup()
    {
        SceneManager.LoadScene("Menu");
    }
}

