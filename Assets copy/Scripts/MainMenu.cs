using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int lives = 3;
    public static int score = 0;
    public static int ques = 0;


    public void PlayGame()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("ques", ques);
        PlayerPrefs.SetInt("lives", lives);
        Debug.Log("started");
        SceneManager.LoadScene("Clock");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
