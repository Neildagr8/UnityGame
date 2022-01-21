using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;

public class level2 : MonoBehaviour
{
    public Text Score;
    public Text info;
    int escore;



    // Start is called before the first frame update
    void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        escore = PlayerPrefs.GetInt("mscore", 0);
        if (escore > 7)
        {
            escore = 3;
        }
        else if (escore > 4)
        {
            escore = 2;
        }
        else if (escore > 2)
        {
            escore = 1;
        }
        else
        {
            escore = 0;
        }
        escore = escore + PlayerPrefs.GetInt("cscore", 0);
        if (escore < 3)
        {
            info.text = "Oh! Please get your test done.";
        }
        else
        {
            info.text = "Yay! You're all good.";
        }
        Score.text = escore.ToString();
        PlayerPrefs.SetInt("escore", escore);
        reference.SetValueAsync(escore);
        PlayerPrefs.Save();
    }
    public void yup()
    {
        SceneManager.LoadScene("picClock");
    }

    public void oyup()
    {
        SceneManager.LoadScene("Menu");
    }
}
